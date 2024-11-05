namespace SerializerInClassroom.Services.Abstractions
{
    public interface ISerializeService<T> where T : class
    {
        List<T> ReadFile(string filePath);
        void WriteFile(List<T> items, string filePath);
    }
}
