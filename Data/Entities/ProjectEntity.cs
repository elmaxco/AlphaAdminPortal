using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities;

public class ProjectEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ClientName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Budget { get; set; }
    public bool Status { get; set; } // true = active, false = inactive

}
