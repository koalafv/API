using System;
using System.Collections.Generic;

namespace API.Models.DataBase.Tables;

public partial class User
{
    public int UsrId { get; set; }

    public string UsrLogin { get; set; } = null!;

    public string UsrPassword { get; set; } = null!;

    public DateTime UsrDate { get; set; }
}
