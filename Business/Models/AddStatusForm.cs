using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models;

public class AddStatusForm
{
    [DataType(DataType.Text)]
    [Display(Name = "Status", Prompt = "Enter Status name")]
    [Required(ErrorMessage = "Required")]
    public string StatusName { get; set; } = null!;
}
