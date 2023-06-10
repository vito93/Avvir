using System;
using System.Collections.Generic;

namespace Avvir.DataLayer.Core;

public partial class Account
{
    public Guid Guid { get; set; }

    public string Uin { get; set; } = null!;

    public string? Name { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long? UinBigint { get; set; }

    public virtual ICollection<AccountAuthorization> AccountAuthorizations { get; set; } = new List<AccountAuthorization>();

    public virtual ICollection<AccountConfirmationToken> AccountConfirmationTokens { get; set; } = new List<AccountConfirmationToken>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Message> MessageAuthors { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; } = new List<UserGroupRole>();
}
