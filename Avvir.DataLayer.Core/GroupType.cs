using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class GroupType
{
    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GroupDict> GroupDicts { get; set; } = new List<GroupDict>();
}
