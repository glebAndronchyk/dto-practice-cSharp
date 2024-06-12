using System.ComponentModel.DataAnnotations;
using lb4.abstractions;
using ValidationLib;

namespace lb4;

public class PublicationDTO : DTOWithId
{
    [Required(ErrorMessage = "Student is required")]
    public StudentDTO student { get; set; }
    
    [EnumRange(typeof(EScientificAchievement), ErrorMessage = "Achievement is not defined")]
    public int achievement { get; set; }
}