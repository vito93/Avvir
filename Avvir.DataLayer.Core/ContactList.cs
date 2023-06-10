using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class ContactList
{
    public Guid Guid { get; set; }

    public Guid MainUserGuid { get; set; }

    public Guid SecondaryUserGuid { get; set; }

    public byte ContactStatus { get; set; }
}
