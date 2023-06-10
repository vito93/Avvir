using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class AccountAuthorization
{
    public Guid Guid { get; set; }

    public Guid AccountGuid { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ValidTo { get; set; }

    public virtual Account Account { get; set; } = null!;
}
