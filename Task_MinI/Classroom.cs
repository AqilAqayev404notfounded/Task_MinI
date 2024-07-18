using Task_MinI.Exception;
using Task_MinI.Exceptions;

namespace Task_MinI;

public class Classroom
{
    static int _id;
    public static int Id { get; private set; }
    public string Name { get; set; }
    public Student[] Students;
    public Typess Type { get; set; }
    public int Limit { get; set; }
    public Classroom(int id, string name, Typess type, int limit)
    {
        Id = _id++;
        Name = name;
        Students = new Student[0];
        Type = type;
        Limit = limit;
        Id = id;
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
        if (Students.Length > Limit)
        {
            Array.Resize(ref Students, Students.Length + 1);
            Students[Students.Length-1]=student;

        }
        else
        {
            throw new LimitRageException("Limiti asdiz");
        }

    }
    public void Delete(int id)
    {
        for (int i = 0; i < Students.Length; i++)
        {
            if (Students[i].Id == id)
            {
                for (int j = i; j < Students.Length - 1; j++)
                {
                    Students[j] = Students[j + 1];
                }
                Array.Resize(ref Students, Students.Length - 1);
                Console.WriteLine("ugurla silindi");
                return;
            }
            else { throw new StudentNotFoundException("telebe tapilmadi"); }

        }
    }
    public void FindId(int id)
    {
        for(int i = 0;i < Students.Length; i++)
        {
            if (Students[i].Id == id) 
            {
                Console.WriteLine($" {Students[i].Name}{Students[i].Surname}{Students[i].Id}" ); 
            }
            else { throw new StudentNotFoundException("telebe tapilmadi"); }
        }
    }






}
