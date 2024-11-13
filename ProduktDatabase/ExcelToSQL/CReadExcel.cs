namespace ExcelToSQL;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;

public static class CReadExcel
{
    internal static List<string> ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return null;
        }

        var excelData = new List<Dictionary<string, string>>();
        var headers = new List<string>();
        using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
        {
            WorkbookPart workbookPart = document.WorkbookPart;
            Sheet sheet = workbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
            WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();

            
            foreach (var row in sheetData.Elements<Row>())
            {
                var rowData = row.Elements<Cell>()
                    .Select((cell, index) => new { Cell = cell, Index = index })
                    .ToDictionary(
                        x => headers.ElementAtOrDefault(x.Index) ?? GetCellValue(document, x.Cell),
                        x => GetCellValue(document, x.Cell)
                    );

                if (row.RowIndex == 1)
                {
                    headers.AddRange(rowData.Values);
                    continue;
                }
                
                excelData.Add(rowData);
            }
        }

        var jsonData = JsonConvert.SerializeObject(excelData, Formatting.Indented);
        var jsonHeaders = JsonConvert.SerializeObject(headers);
        return [jsonHeaders, jsonData];
    }

    private static string GetCellValue(SpreadsheetDocument doc, Cell cell)
    {
        SharedStringTablePart stringTablePart = doc.WorkbookPart.SharedStringTablePart;
        string value = cell.CellValue.InnerText;
        
        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
        {
            return stringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;
        }
        return value;
    }
}