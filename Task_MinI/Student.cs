namespace Task_MinI;

public class Student
{
    static int _id;
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Student(string name ,string surname,int id)
    {
        Name = name;
        Surname = surname;
        Id = _id++;
        Id = id;
    }
}
