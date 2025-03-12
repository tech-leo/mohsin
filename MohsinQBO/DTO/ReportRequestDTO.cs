using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReportRequestDTO
{
    public string Title { get; set; }
    public Guid? Accountid { get; set; }
    public IDictionary<string, string> ReportParameters { get; set; }
}
