using System;
using System.Collections.Generic;

namespace API.Models.DataBase.Tables;

public partial class User
{
    public int UsrId { get; set; }

    public string UsrWorkerPin { get; set; } = null!;

    public string UsrWorkerNumber { get; set; } = null!;

    public int UserPermisionId { get; set; }
    public string? UserName { get; set; }
    public string? UserSurname { get; set; }
}
