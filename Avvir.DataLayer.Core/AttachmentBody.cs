using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class AttachmentBody
{
    public Guid Guid { get; set; }

    public Guid HeaderGuid { get; set; }

    public Guid RowGuidcol { get; set; }

    public byte[] Body { get; set; } = null!;

    public virtual AttachmentHeader Header { get; set; } = null!;
}
