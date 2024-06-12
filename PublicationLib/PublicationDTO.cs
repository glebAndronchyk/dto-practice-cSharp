using lb4.abstractions;

namespace lb4;

public class PublicationDTO : DTOWithId
{
    public StudentDTO student { get; set; }
    public int achievement { get; set; }
}