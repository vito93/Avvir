using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class AuthorizationToken
{
    public Guid Guid { get; set; }

    public Guid AccountGuid { get; set; }

    public DateTime CreateDate { get; set; }
}
