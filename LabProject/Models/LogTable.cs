using System;
using System.Collections.Generic;

namespace LabProject.Models;

public partial class LogTable
{
    public int Id { get; set; }

    public string Details { get; set; } = null!;

    public DateTime LogDate { get; set; }
}
