using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class GroupDict
{
    public Guid Guid { get; set; }

    public string? GroupName { get; set; }

    public Guid GroupTypeGuid { get; set; }

    public Guid GroupOwnerGuid { get; set; }

    public virtual GroupType GroupType { get; set; } = null!;

    public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; } = new List<UserGroupRole>();
}
