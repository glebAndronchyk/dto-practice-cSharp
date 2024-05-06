using ScientificAchievementsLibrary;
using StudentsLibrary;

namespace lb4.entities.Post;

public class Publication
{
    public Student Student { get; private set; }
    public EScientificAchievement Achievement { get; private set; }

    public Publication(Student student, EScientificAchievement achievement)
    {
        this.Student = student;
        this.Achievement = achievement;
    }
}