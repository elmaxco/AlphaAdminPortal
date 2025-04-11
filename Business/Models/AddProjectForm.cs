using System.ComponentModel.DataAnnotations;


namespace Business.Models;

public class AddProjectForm
{
    [DataType(DataType.Text)]
    [Display(Name = "Project Name", Prompt = "Enter project name")]
    [Required(ErrorMessage = "Required")]
    public string Name { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Client Name", Prompt = "Enter client name")]
    [Required(ErrorMessage = "Required")]   
    public string ClientName { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    [Display(Name = "Descriotion", Prompt = "Enter description")]
    [Required(ErrorMessage = "Required")]    
    public string Description { get; set; } = null!;

    [DataType(DataType.Date)]
    [Display(Name = "Start Date", Prompt = "Start date")]
    [Required(ErrorMessage = "Required")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [DataType(DataType.Date)]
    [Display(Name = "End Date", Prompt = "End date")]
    [Required(ErrorMessage = "Required")]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(10);

    [DataType(DataType.Currency)]
    [Display(Name = "Budget", Prompt = "Budget")]
    [Required(ErrorMessage = "Required")]
    [Range(0, double.MaxValue, ErrorMessage = "Please provide a correct amount for the budget")]
    public decimal Budget { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Status", Prompt = "Enter status")]
    [Required(ErrorMessage = "Required")]
    public bool Status { get; set; }
    public string StatusList { get; set; } = "On";
}

