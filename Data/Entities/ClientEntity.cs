﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities;

public class ClientEntity
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
 
    public string? Phone { get; set; } 
   
    public string? Address { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
}
