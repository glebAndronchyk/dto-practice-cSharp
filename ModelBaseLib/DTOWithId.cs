using System;
using System.ComponentModel.DataAnnotations;

namespace lb4.abstractions;

public class DTOWithId
{
    [Required(ErrorMessage = "Id is not defined")]
    public string id { get; set; }
}