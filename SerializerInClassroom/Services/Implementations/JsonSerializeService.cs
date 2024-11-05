using Newtonsoft.Json;
using SerializerInClassroom.Services.Abstractions;

namespace SerializerInClassroom.Services.Implementations
{
    public class JsonSerializeService<T> : ISerializeService<T> where T : class
    {
    
        public List<T> ReadFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(result) ?? new();
            }
        }

        public void WriteFile(List<T> items, string filePath)
        {
            string json = JsonConvert.SerializeObject(items);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(json);
            }
        }
    }
}
