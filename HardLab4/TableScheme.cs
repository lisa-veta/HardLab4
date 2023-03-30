using System.Text.Json.Serialization;
using System.Text.Json;

namespace HardLab4
{
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

}