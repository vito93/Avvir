using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class Message2Account
{
    public Guid Guid { get; set; }

    public Guid MessageGuid { get; set; }

    public Guid AccountGuid { get; set; }

    public DateTime? Viewed { get; set; }
}
