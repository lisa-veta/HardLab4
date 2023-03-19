using HardLab4;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace HardLab4
{
    public class Programm
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TableScheme tableScheme = TableScheme.ReadFile("Schemes\\Book.json");
            Console.WriteLine(tableScheme.name);
            foreach (Column colunm in tableScheme.Columns)
            {
                Console.WriteLine(colunm.Name);
                Console.WriteLine(colunm.Type);
            }
        }
    }

    public class TableScheme
    {
        public string Name { get; set; }

        // в таблице есть список столбцов
        public List<Column> Columns { get; set;  }

        // конструктор, чтобы заполнить объект при создании
        public static TableScheme ReadFile(string path)
        {
            return JsonSerializer.Deserialize<TableScheme>(File.ReadAllText(path));
        }
    }

    public class Column
    {
        public string Name { get; set; }

        // у колонки есть тип данных в ней
        public string Type { get; set; }
    }

    public enum ColumnType
    {
          Int, Float, String, Uint
    }

    public class Table
    {
        public List<Row> Rows { get; }
        private TableScheme tb { get; }
    }

    public class Row
    {
        public Dictionary<Column, object> Data { get; }
    }


}
