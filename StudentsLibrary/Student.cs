namespace StudentsLibrary;

public class Student
{
    private string _name;
    private string _surname;
    private DateTime _appliedDate;

    public string FullName
    {
        get => $"{_name} {_surname}";
    }

    public DateTime AppliedDate
    {
        get => _appliedDate;
    }

    public Student(string name, string surname, DateTime appliedDate)
    {
        _name = name;
        _surname = surname;
        appliedDate = _appliedDate;
    }
}