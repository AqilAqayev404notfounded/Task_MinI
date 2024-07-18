namespace Task_MinI.Exception;
using System;


public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(string message)
    : base(message)
    {

    }
}

