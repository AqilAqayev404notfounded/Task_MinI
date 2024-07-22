using System.Data;
using Task_MinI.Exception;
using Task_MinI.Exceptions;

namespace Task_MinI.Models;

public class Classroom
{
    static int _id;
    public static int Id { get; private set; }
    public string Name { get; set; }
    public List<Student> Students;
    public Typess Type { get; set; }
    public int Limit { get; set; }
    public Classroom(string name, Typess type)
    {
        Id = _id++;
        Name = name;
        Students = new List<Student>();
        Type = type;
        if (type == Typess.Backend)
        {
            Limit = 20;
        }
        else if (type == Typess.Frontend)
        {
            Limit = 15;
        }

    }
    public void StudentAdd(Student student)
    {
        if (Students.Count < Limit)
        {

            Students.Add(student);
        }
        else
        {
            throw new LimitRageException("Limiti asdiz");
        }

    }
    public void Delete(int id)
    {

        Student student = FindId(id);
        Students.Remove(student);


    }
    public Student FindId(int id)
    {

        var student = Students.Find(student => student.Id == id);
        if (student != null)
        {
            throw new StudentNotFoundException("telebe tapilmadi");
        }
        else
        {
            return student;
        }
    }






}
