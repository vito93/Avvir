using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class ContactListRequest
{
    public Guid Guid { get; set; }

    public Guid SenderGuid { get; set; }

    public Guid ReceiverGuid { get; set; }

    public DateTime Created { get; set; }

    public byte RequestStatus { get; set; }
}
