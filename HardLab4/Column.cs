using System.Text.Json.Serialization;

namespace HardLab4
{
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

}