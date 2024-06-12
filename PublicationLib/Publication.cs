using lb4.abstractions;
using lb4.Enums;

namespace lb4;

public class Publication : ItemWithId
{
    public Student Student { get; private set; }
    public EScientificAchievement Achievement { get; private set; }

    public Publication(Student student, EScientificAchievement achievement, string id)
    {
        Id = id;
        Student = student;
        Achievement = achievement;
    }

    public override string ToString()
    {
        return $"{Student.FullName} - Wrote publication with achievement: {ScientificAchievementMap.DescriptionMap[Achievement]}";
    }
}