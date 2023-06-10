using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class GroupRole
{
    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;
}
