using lb4.abstractions;

namespace lb4;

public class PublicationDTO : DTOWithId
{
    public Student student { get; set; }
    public EScientificAchievement achievement { get; set; }
}