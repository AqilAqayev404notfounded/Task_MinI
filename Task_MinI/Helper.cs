namespace Task_MinI;

public static class Helper
{
    public static bool IsValidName(this string name)
    {
        return name.Length >= 3 && char.IsUpper(name[0]) && !name.Contains(' ');
    }

    public static bool IsValidSurname(this string surname)
    {
        return surname.Length >= 3 && char.IsUpper(surname[0]) && !surname.Contains(' ');
    }

    public static bool IsValidClassroomName(this string classroomName)
    {
        return classroomName.Length == 5 && classroomName.Take(2).All(char.IsUpper) && classroomName.Skip(2).All(char.IsDigit);
    }
}
