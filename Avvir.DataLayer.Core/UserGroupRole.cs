using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class UserGroupRole
{
    public Guid Guid { get; set; }

    public Guid AccountGuid { get; set; }

    public Guid GroupGuid { get; set; }

    public Guid GroupRoleGuid { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual GroupDict Group { get; set; } = null!;
}
