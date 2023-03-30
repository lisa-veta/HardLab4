namespace HardLab4
{
    public class Printer
    {
        public static void PrintTable(Table table)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for(int j = 0; j < table.Scheme.Columns.Count; j++)
                {
                    Console.Write(table.Rows[i].Data[table.Scheme.Columns[j]] + " ");
                }
                Console.WriteLine();
            }
        }
    }

}