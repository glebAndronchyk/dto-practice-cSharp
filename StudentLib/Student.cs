using lb4.abstractions;

namespace lb4;

public class Student : ItemWithId
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public DateTime AppliedDate { get; private set; }
    public string FullName
    {
        get => Name + " " + Surname;
    }

    public Student()
    { }

    public Student(string name, string surname, DateTime appliedDate, string id)
    {
        Id = id;
        Name = name;
        Surname = surname;
        AppliedDate = appliedDate;
    }

    public override string ToString()
    {
        return $"{Name} {Surname} - Applied On: {AppliedDate}";
    }
}