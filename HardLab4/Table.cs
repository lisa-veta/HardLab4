namespace HardLab4
{
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
        public TableScheme Scheme { get; set; }
    }

}