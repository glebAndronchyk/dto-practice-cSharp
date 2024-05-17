using System;

namespace lb4;

public class Student
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public DateTime AppliedDate { get; private set; }

    public Student(string name, string surname, DateTime appliedDate)
    {
        Name = name;
        Surname = surname;
        AppliedDate = appliedDate;
    }
}