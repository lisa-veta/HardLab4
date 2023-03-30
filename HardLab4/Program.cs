using HardLab4;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Dynamic;

namespace HardLab4
{
    public class Programm
    {
        static void Main()
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //TableScheme tableScheme = TableScheme.ReadFile("Schemes\\Book.json");
            //Console.WriteLine(tableScheme.Name);
            //foreach (Column colunm in tableScheme.Columns)
            //{
            //    Console.WriteLine(colunm.Name);
            //    Console.WriteLine(colunm.Type);
            //}

            Inform.Get("Schemes\\Book.json", "Schemes\\Book.csv");
        }
    }

    public class TableScheme
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // в таблице есть список столбцов
        [JsonPropertyName("columns")]
        public List<Column> Columns { get; set;  }

        // конструктор, чтобы заполнить объект при создании
        public static TableScheme ReadFile(string path)
        {
            return JsonSerializer.Deserialize<TableScheme>(File.ReadAllText(path));
        }
    }

    public class Column
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        // у колонки есть тип данных в ней
        public ColumnType Type { get; set; }

    }

    public enum ColumnType
    {
        Uint, Int, Double, Float, String,  DateTime
    }

    public class Table
    {
        public List<Row> Rows { get; }
        private TableScheme  Scheme { get; }
    }

    public class Row
    {
        public Dictionary<Column, object> Data { get; }
    }


    public class Inform
    {
        public static void Get(string pathJson, string pathTable)
        {
            TableScheme tableScheme = TableScheme.ReadFile(pathJson);
            Table table = new Table();

            string[] lines = File.ReadAllLines(pathTable);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(";");

                if(line.Length > tableScheme.Columns.Count)
                {
                    throw new Exception();
                }
                else
                {
                    Row row = new Row();
                }
            }
        }

        static Row RowRead(string[] line, int numberOfLine, string pathTable)
        {
            Row row = new Row();

            for(int i = 0; i < line.Length; i++)
            {
                
            }

        }



    }

}
