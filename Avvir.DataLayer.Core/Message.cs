using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class Message
{
    public Guid Guid { get; set; }

    public Guid AuthorGuid { get; set; }

    public Guid? ReceiverGuid { get; set; }

    public string MessageBody { get; set; } = null!;

    public Guid? GroupGuid { get; set; }

    public Guid? ReplyMessageGuid { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Edited { get; set; }

    public virtual Account Author { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Account? Receiver { get; set; }
}
