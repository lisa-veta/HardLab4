using HardLab4;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Dynamic;
using System.Data;

namespace HardLab4
{
    public class Programm
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //TableScheme tableScheme = TableScheme.ReadFile("Schemes\\Book.json");
            //Console.WriteLine(tableScheme.Name);
            //foreach (Column colunm in tableScheme.Columns)
            //{
            //    Console.WriteLine(colunm.Name);
            //    Console.WriteLine(colunm.Type);
            //}
            
            Table table = Inform.Get("Schemes\\Book.json", "Schemes\\Book.csv");
            Printer.PrintTable(table);
            
        }
    }

    public class TableScheme
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // в таблице есть список столбцов
        [JsonPropertyName("columns")]
        public List<Column> Columns { get; set; }

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
        public string Type { get; set; }
        // у колонки есть тип данных в ней
        //public Object Type
        //{
        //    get
        //    {
        //        return this.Type;
        //    }
        //    set
        //    {
        //        switch (value)
        //        {
        //            case "string":
        //                {
        //                    Type = ColumnType.String;
        //                    break;
        //                }
        //            case "uint":
        //                {
        //                    Type = ColumnType.Uint;
        //                    break;
        //                }
        //        }
        //    }
    }

    //public enum ColumnType
    //{
    //    Uint, Int, Double, Float, String, DateTime
    //}

    public class Table
    {
        public List<Row> Rows { get; set; }
        public Table()
        {
            Rows = new List<Row>();
        }
        ///private TableScheme Scheme { get; set; }
    }

    public class Row
    {
        public Dictionary<Column, object> Data { get; set; }
        public Row()
        {
            Data = new Dictionary<Column, object>();
        }
    }


    public class Inform
    {
        public static Table Get(string pathScheme, string pathTable)
        {
            TableScheme tableScheme = TableScheme.ReadFile(pathScheme);
            Table table = new Table();

            string[] lines = File.ReadAllLines(pathTable);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(";");

                if (line.Length > tableScheme.Columns.Count)
                {
                    throw new Exception();
                }
                else
                {
                    Row row = RowRead(line, i, pathTable, tableScheme);
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        static Row RowRead(string[] line, int numberOfLine, string pathTable, TableScheme tableScheme)
        {
            Row row = new Row();

            for (int i = 0; i < line.Length; i++)
            {
                switch (tableScheme.Columns[i].Type)
                {
                    case "uint":
                        {
                            if (uint.TryParse(line[i], out uint number))
                            {
                                row.Data.Add(tableScheme.Columns[i], number);
                            }
                            else
                            {
                                throw new ArgumentException($"В файле {pathTable} в строке {numberOfLine + 1} в столбце {i + 1} записаны некорректные данные");
                            }
                            break;
                        }
                    case "string":
                        {
                            row.Data.Add(tableScheme.Columns[i], line[i]);
                            break;
                        }
                }
            }
            return row;
        }

    }

    public class Printer
    {
        public static void PrintTable(Table table)
        {

        }
    }

}