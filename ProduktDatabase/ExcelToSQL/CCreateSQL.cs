using Microsoft.Extensions.Primitives;

namespace ExcelToSQL;

using System.IO;
using System.Text;
using Newtonsoft.Json;

public static class CCreateSQL
{
    private static void CreateFile(string filePath)
    {
        if(File.Exists(filePath))
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
        List<Dictionary<string, string>> data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
        Dictionary<string, string> tableData = data.First().ToDictionary(d => d.Key.Replace(' ', '_'), d => GetValueType(d.Value));

        StringBuilder createTable = new StringBuilder("CREATE TABLE TableName (\nID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, \n");
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