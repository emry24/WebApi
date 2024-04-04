using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos;

public class ProgramDetailsDto
{
    public int ProgramDetailsNumber { get; set; }
    public string ProgramDetailsTitle { get; set; } = null!;
    public string? ProgramDetailsDescription { get; set; }
}
