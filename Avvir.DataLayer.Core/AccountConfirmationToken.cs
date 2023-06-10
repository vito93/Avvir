using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class AccountConfirmationToken
{
    public Guid Guid { get; set; }

    public Guid AccountGuid { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsUsed { get; set; }

    public virtual Account Account { get; set; } = null!;
}
