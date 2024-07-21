using Newtonsoft.Json;
using Task_MinI.Exceptions;
using Task_MinI.Models;

restart:
Console.WriteLine("Menu:");
Console.WriteLine("1. Classroom yarat");
Console.WriteLine("2. Student yarat");
Console.WriteLine("3. Butun Telebeleri ekrana cixart");
Console.WriteLine("4. Secilmis sinifdeki telebeleri ekrana cixart");
Console.WriteLine("5. Telebe sil");
Console.WriteLine("6. Cixis");
Console.Write("Seciminizi edin: ");
string classroomPath = "C:\\Users\\Muhammad\\Desktop\\c#\\Task_MinI\\Task_MinI\\data.json";
string studentPath = "C:\\Users\\Muhammad\\Desktop\\c#\\Task_MinI\\Task_MinI\\student.json";

var choice = Console.ReadLine();
switch (choice)
{
    case "1":
        try
        {
            string path = "C:\\Users\\Muhammad\\Desktop\\c#\\Task_MinI\\Task_MinI\\data.json";
            Console.Write("Sinif adi daxil edin: ");
            var name = Console.ReadLine();
            if (!name.IsValidClassroomName())
            {
                throw new ArgumentException("Duzgun ad daxil et");
               goto restart;
            }

            Console.Write("Sinif tipi (Backend/Frontend) daxil edin: ");
            var type = Console.ReadLine();
            Classroom classroom = null;
            if (type == Typess.Backend.ToString())
            {
                classroom = new(name, Typess.Backend);
            }
            else if (type == Typess.Frontend.ToString())
            {
                classroom = new(name, Typess.Frontend);
            }

            if (classroom is null)
            {
                throw new Exception("Clasroom bosdur");
                goto restart;

            }
            string result;

            using (StreamReader sr = new(path))
            {
                result = sr.ReadToEnd();
            }
            List<Classroom> classrooms = JsonConvert.DeserializeObject<List<Classroom>>(result);

            if (classrooms is null)
                classrooms = new();
            classrooms.Add(classroom);
            var json = JsonConvert.SerializeObject(classrooms);



            if (classrooms is null)
            {
                classrooms = new List<Classroom>();
            }
            using (StreamWriter sw = new(path))
            {
                sw.WriteLine(json);
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xeta: {ex.Message}");
        }
        Console.WriteLine("Classroom ugurla yaradildi");
        goto restart;

    case "2":

        try
        {
            Console.Write("Telebenin adi daxil edin: ");
            var studentName = Console.ReadLine();
            if (!studentName.IsValidName())
            {
                throw new ArgumentException("Duzgun ad daxil et");
            }

            Console.Write("Telebenin soyadi daxil edin: ");
            var studentSurname = Console.ReadLine();
            if (!studentSurname.IsValidSurname())
            {
                throw new ArgumentException("Duzgun soyad daxil et");
            }

            List<Classroom> classrooms;
            if (File.Exists(classroomPath))
            {
                string result = File.ReadAllText(classroomPath);
                classrooms = JsonConvert.DeserializeObject<List<Classroom>>(result) ?? new List<Classroom>();
            }
            else
            {
                throw new Exception("Heç bir sinif yoxdur. Əvvəlcə sinif yaradın.");
            }

            Console.WriteLine("Munku sinifler :");
            for (int i = 0; i < classrooms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {classrooms[i].Name} ({classrooms[i].Type})");
            }

            Console.Write("Telebeni elave etmek ucun sinif nomresini daxil edin: ");
            if (!int.TryParse(Console.ReadLine(), out int classNumber) || classNumber < 1 || classNumber > classrooms.Count)
            {
                throw new ArgumentException("Duzgun sinif nomresi daxil edin");
            }

            var selectedClassroom = classrooms[classNumber - 1];
            var student = new Student(studentName, studentSurname);
            selectedClassroom.StudentAdd(student);

            var classroomJson = JsonConvert.SerializeObject(classrooms, Formatting.Indented);
            File.WriteAllText(classroomPath, classroomJson);

            List<Student> students;
            if (File.Exists(studentPath))
            {
                string result = File.ReadAllText(studentPath);
                students = JsonConvert.DeserializeObject<List<Student>>(result) ?? new List<Student>();
            }
            else
            {
                students = new List<Student>();
            }

            students.Add(student);
            var studentJson = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(studentPath, studentJson);

            Console.WriteLine("Student ugurla yaradildi ve sinifa elave olundu");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xeta: {ex.Message}");
        }
        goto restart;

    case "3":
        try
        {
            if (File.Exists(studentPath))
            {
                string result = File.ReadAllText(studentPath);
                var students = JsonConvert.DeserializeObject<List<Student>>(result) ?? new List<Student>();
                foreach (var student in students)
                {
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xeta: {ex.Message}");
        }
        goto restart;
    case "4":
        try
        {
            if (File.Exists(studentPath))
            {
                string result = File.ReadAllText(studentPath);
                var students = JsonConvert.DeserializeObject<List<Student>>(result) ?? new List<Student>();
                foreach (var student in students)
                {
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xeta: {ex.Message}");
        }
        goto restart;

    case "5":
        try
        {
            Console.Write("Telebenin Id daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                List<Student> students;
                if (File.Exists(studentPath))
                {
                    string result = File.ReadAllText(studentPath);
                    students = JsonConvert.DeserializeObject<List<Student>>(result) ?? new List<Student>();
                    var student = students.Find(s => s.Id == studentId);
                    if (student != null)
                    {
                        students.Remove(student);
                        var json = JsonConvert.SerializeObject(students, Formatting.Indented);
                        File.WriteAllText(studentPath, json);
                        Console.WriteLine("Telebe silindi");
                    }
                    else
                    {
                        Console.WriteLine("Telebe tapilmadi");
                    }
                }
            }
            else
            {
                Console.WriteLine("Duzgun Id daxil edin");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xeta: {ex.Message}");
        }
        goto restart;
    case "6":
    return;
default:
    Console.WriteLine("Yanlış seçim!");
    break;

}