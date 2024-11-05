using System.Xml.Serialization;

namespace SerializerInClassroom.Models;
[XmlRoot("person", Namespace = "")]


public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }
}
