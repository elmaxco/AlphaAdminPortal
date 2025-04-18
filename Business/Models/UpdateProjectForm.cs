﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models;

public class UpdateProjectForm
{
    [Required]
    public int Id { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Project Name", Prompt = "Enter project name")]
    [Required(ErrorMessage = "Required")]
    public string Name { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Client Name", Prompt = "Enter client name")]
    [Required(ErrorMessage = "Required")]
    public string ClientName { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    [Display(Name = "Description", Prompt = "Enter project description")]
    [Required(ErrorMessage = "Required")]
    public string Description { get; set; } = null!;

    [DataType(DataType.Date)]
    [Display(Name = "Start Date", Prompt = "Select start date")]
    [Required(ErrorMessage = "Required")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [DataType(DataType.Date)]
    [Display(Name = "End Date", Prompt = "Select end date")]
    [Required(ErrorMessage = "Required")]
    public DateTime EndDate { get; set; } = DateTime.Now;

    [DataType(DataType.Currency)]
    [Display(Name = "Budget", Prompt = "Enter budget")]
    [Required(ErrorMessage = "Required")]
    [Range(0, double.MaxValue, ErrorMessage = "Please provide a positive number for the budget")]
    public decimal Budget { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Status", Prompt = "Enter status")]
    [Required(ErrorMessage = "Required")]
    public bool Status { get; set; }

}