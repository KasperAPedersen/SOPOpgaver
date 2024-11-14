using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MetroFramework.Forms;
using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class ExcelToSQL : MetroForm
    {
        public ExcelToSQL()
        {
            InitializeComponent();
            panel1.DragEnter += control_DragEnter;
            panel1.DragDrop += control_DragDrop;
        }

        private void control_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Allow copy effect
            }
            else
            {
                e.Effect = DragDropEffects.None; // Disallow drop
            }
        }

        private void control_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string filePath = file;

                List<string> fileData = CReadExcel.ReadFile(filePath);
                FileInfo fileInfo = new FileInfo(filePath);
                CCreateSQL.WriteToFile($"{fileInfo.DirectoryName}\\SQL\\{Path.GetFileNameWithoutExtension(filePath)}\\{Path.GetFileNameWithoutExtension(filePath)}_table.sql", CCreateSQL.JsonToSqlTables(fileData[1]));
                CCreateSQL.WriteToFile($"{fileInfo.DirectoryName}\\SQL\\{Path.GetFileNameWithoutExtension(filePath)}\\{Path.GetFileNameWithoutExtension(filePath)}_insert.sql", CCreateSQL.JSONToSQLData(fileData[1]));
            }
            Close();
        }
    }

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
    
    public static class CCreateSQL
    {
        private static void CreateFile(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Directory.CreateDirectory(fileInfo.DirectoryName);
            }
            
            if (File.Exists(filePath))
            {
                Console.WriteLine("File already exists.");
                return;
            }
            
            File.Create(filePath).Close();
        }

        internal static void WriteToFile(string filePath, string data)
        {
            if (!File.Exists(filePath)) CreateFile(filePath);
            File.WriteAllText(filePath, data);
        }

        internal static string JsonToSqlTables(string json)
        {
            List<Dictionary<string, string>> data =
                JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            Dictionary<string, string> tableData =
                data.First().ToDictionary(d => d.Key.Replace(' ', '_'), d => GetValueType(d.Value));

            StringBuilder createTable =
                new StringBuilder("CREATE TABLE TableName (\nID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, \n");
            createTable.Append(string.Join(", \n", tableData.Select(d => $"{d.Key} {d.Value}")));
            createTable.Append("\n);");

            return createTable.ToString();
        }

        internal static string JSONToSQLData(string json)
        {
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            var headers = string.Join(", ", data.First().Keys.Select(k => k.Replace(' ', '_')));
            var values = string.Join(",\n", data.Select(row =>
                $"({string.Join(", ", row.Values.Select(v => $"'{v}'"))})"));

            return $"INSERT INTO TableName ({headers}) VALUES \n{values};";
        }

        private static string GetValueType(string value)
        {
            return value switch
            {
                _ when int.TryParse(value, out _) => "INT",
                _ when long.TryParse(value, out _) => "BIGINT",
                _ when decimal.TryParse(value, out _) => "DECIMAL",
                _ when DateTime.TryParse(value, out _) => "DATETIME",
                _ => "VARCHAR(255)"
            };
        }
    }
}
