namespace Task_MinI.Models;

public class Student
{
    static int _id;
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Student(string name, string surname)
    {
        Name = name;
        Surname = surname;
        Id = _id++;
        
    }
}
