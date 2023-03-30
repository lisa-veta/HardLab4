using HardLab4;
using System;
using System.Dynamic;
using System.Data;
using System.IO;
using System.Collections;
using System.Xml.Linq;

namespace HardLab4
{
    public class Programm
    {
        static void Main()
        {
            string pathScheme = "Schemes\\Book.json";
            string pathTable = "Schemes\\Book.csv";

            Table table = TableData.GetInfoFromTable(pathScheme, pathTable);
            Printer.PrintTable(table);
        }
    }

}