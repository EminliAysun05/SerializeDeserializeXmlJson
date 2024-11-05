using System.Xml.Serialization;



namespace SerializerInClassroom.Models;
[XmlRoot("people", Namespace = "")]


public class People
{
    public List<Person> PersonList { get; set; }
}
