using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class AttachmentHeader
{
    public Guid Guid { get; set; }

    public string Filename { get; set; } = null!;

    public string? MimeType { get; set; }

    public DateTime? Created { get; set; }

    public Guid? MessageGuid { get; set; }

    public virtual ICollection<AttachmentBody> AttachmentBodies { get; set; } = new List<AttachmentBody>();
}
