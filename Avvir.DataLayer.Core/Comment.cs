using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class Comment
{
    public Guid Guid { get; set; }

    public Guid MessageGuid { get; set; }

    public Guid AuthorGuid { get; set; }

    public string Body { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual Account Author { get; set; } = null!;

    public virtual Message Message { get; set; } = null!;
}
