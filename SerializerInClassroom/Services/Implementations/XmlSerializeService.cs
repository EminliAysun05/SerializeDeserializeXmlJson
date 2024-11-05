using SerializerInClassroom.Services.Abstractions;
using System.Xml.Serialization;

namespace SerializerInClassroom.Services.Implementations
{
    public class XmlSerializeService<T> : ISerializeService<T> where T : class
    {
    
        private readonly XmlSerializer _serializer;

        public XmlSerializeService()
        {
            _serializer = new XmlSerializer(typeof(List<T>));
        }
        public List<T> ReadFile(string filePath)
        {
            using (StreamReader reader = new(filePath))
            {
                return (List<T>)_serializer.Deserialize(reader);
            }
        }

        public void WriteFile(List<T> items, string filePath)
        {
            using (StreamWriter writer = new(filePath))
            {
                _serializer.Serialize(writer, items);
            }
        }
    }
}
