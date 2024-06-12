using System;
using System.ComponentModel.DataAnnotations;
using lb4.abstractions;

namespace lb4;

public class StudentDTO : DTOWithId
{
    [Required(ErrorMessage = "Full Name is Required")]
    [MaxLength(101, ErrorMessage = "Full Name cannot exceed 101 characters")]
    public string fullName { get; set; }
    
    [Required(ErrorMessage = "Applied Date is Required")]
    [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(\d{4}) (0[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$",
        ErrorMessage = "invalid date format")]
    public string appliedDate { get; set; }
}
