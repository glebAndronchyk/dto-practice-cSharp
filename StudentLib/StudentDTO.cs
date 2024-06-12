﻿using System;
using lb4.abstractions;

namespace lb4;

public class StudentDTO : DTOWithId
{
    public string fullName { get; set; }
    public string appliedDate { get; set; }
}