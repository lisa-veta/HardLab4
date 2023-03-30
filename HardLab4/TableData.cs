﻿namespace HardLab4
{
    public class TableData
    {
        public static Table GetInfoFromTable(string pathScheme, string pathTable)
        {
            TableScheme tableScheme = TableScheme.ReadFile(pathScheme);
            Table table = new Table();
            table.Scheme = tableScheme;

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
                    Row row = ReadRow(line, i, pathTable, tableScheme);
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        static Row ReadRow(string[] line, int numberOfLine, string pathTable, TableScheme tableScheme)
        {
            Row row = new Row();

            for (int i = 0; i < line.Length; i++)
            {
                switch (tableScheme.Columns[i].Type)
                {
                    case "uint":
                        {
                            row.Data.Add(tableScheme.Columns[i], CheckUint(line[i], pathTable, numberOfLine, i));
                            break;
                        }
                    case "int":
                        {
                            row.Data.Add(tableScheme.Columns[i], CheckInt(line[i], pathTable, numberOfLine, i));
                            break;
                        }
                    case "float":
                        {
                            row.Data.Add(tableScheme.Columns[i], CheckFloat(line[i], pathTable, numberOfLine, i));
                            break;
                        }
                    case "double":
                        {
                            row.Data.Add(tableScheme.Columns[i], CheckDouble(line[i], pathTable, numberOfLine, i));
                            break;
                        }
                    case "datetime":
                        {
                            row.Data.Add(tableScheme.Columns[i], CheckDateTime(line[i], pathTable, numberOfLine, i));
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

       private static int CheckInt(string element, string pathTable, int numberOfLine, int numberOfColumn)
        {
            if (int.TryParse(element, out int number))
            {
                return number;
            }
            throw new ArgumentException($"Ошибка в файле <{pathTable}>, в строке номер {numberOfLine + 1}, столбце номер  {numberOfColumn + 1}. Описание ошибки: некорректные данные");
        }

        private static uint CheckUint(string element, string pathTable, int numberOfLine, int numberOfColumn)
        {
            if (uint.TryParse(element, out uint number))
            {
                return number;
            }
            throw new ArgumentException($"Ошибка в файле <{pathTable}>, в строке номер {numberOfLine + 1}, столбце номер  {numberOfColumn + 1}. Описание ошибки: некорректные данные");
        }

        private static float CheckFloat(string element, string pathTable, int numberOfLine, int numberOfColumn)
        {
            if (float.TryParse(element, out float number))
            {
                return number;
            }
            throw new ArgumentException($"Ошибка в файле <{pathTable}>, в строке номер {numberOfLine + 1}, столбце номер  {numberOfColumn + 1}. Описание ошибки: некорректные данные");
        }

        private static double CheckDouble(string element, string pathTable, int numberOfLine, int numberOfColumn)
        {
            if (double.TryParse(element, out double number))
            {
                return number;
            }
            throw new ArgumentException($"Ошибка в файле <{pathTable}>, в строке номер {numberOfLine + 1}, столбце номер  {numberOfColumn + 1}. Описание ошибки: некорректные данные");
        }

        private static DateTime CheckDateTime(string element, string pathTable, int numberOfLine, int numberOfColumn)
        {
            if (DateTime.TryParse(element, out DateTime number))
            {
                return number;
            }
            throw new ArgumentException($"Ошибка в файле <{pathTable}>, в строке номер {numberOfLine + 1}, столбце номер  {numberOfColumn + 1}. Описание ошибки: некорректные данные");
        }

    }

}