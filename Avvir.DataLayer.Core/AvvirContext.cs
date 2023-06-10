using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Avvir.DataLayer.Core;

public partial class AvvirContext : DbContext
{
    public AvvirContext()
    {
    }

    public AvvirContext(DbContextOptions<AvvirContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountAuthorization> AccountAuthorizations { get; set; }

    public virtual DbSet<AccountConfirmationToken> AccountConfirmationTokens { get; set; }

    public virtual DbSet<AttachmentBody> AttachmentBodies { get; set; }

    public virtual DbSet<AttachmentHeader> AttachmentHeaders { get; set; }

    public virtual DbSet<AuthorizationToken> AuthorizationTokens { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ContactList> ContactLists { get; set; }

    public virtual DbSet<ContactListRequest> ContactListRequests { get; set; }

    public virtual DbSet<GroupDict> GroupDicts { get; set; }

    public virtual DbSet<GroupRole> GroupRoles { get; set; }

    public virtual DbSet<GroupType> GroupTypes { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Message2Account> Message2Accounts { get; set; }

    public virtual DbSet<UserGroupRole> UserGroupRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=avvir-dev.vikklein.com;Initial Catalog=Avvir;User ID=Eugene;Password=Gesha73;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("Account");

            entity.HasIndex(e => e.Uin, "IX_UIN_UNIQUE").IsUnique();

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Uin)
                .HasMaxLength(50)
                .HasColumnName("UIN");
            entity.Property(e => e.UinBigint)
                .HasComputedColumnSql("(CONVERT([bigint],[UIN]))", false)
                .HasColumnName("UIN_Bigint");
        });

        modelBuilder.Entity<AccountAuthorization>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("AccountAuthorization");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.AccountGuid).HasColumnName("AccountGUID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ValidTo).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountAuthorizations)
                .HasForeignKey(d => d.AccountGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountAuthorization_Account");
        });

        modelBuilder.Entity<AccountConfirmationToken>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("AccountConfirmationToken");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.AccountGuid).HasColumnName("AccountGUID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountConfirmationTokens)
                .HasForeignKey(d => d.AccountGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountConfirmationToken_Account");
        });

        modelBuilder.Entity<AttachmentBody>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("AttachmentBody");

            entity.HasIndex(e => e.RowGuidcol, "rowguidcol_unique").IsUnique();

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.HeaderGuid).HasColumnName("HeaderGUID");
            entity.Property(e => e.RowGuidcol)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("RowGUIDCol");

            entity.HasOne(d => d.Header).WithMany(p => p.AttachmentBodies)
                .HasForeignKey(d => d.HeaderGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttachmentBody_AttachmentHeader");
        });

        modelBuilder.Entity<AttachmentHeader>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("AttachmentHeader");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Created).HasPrecision(3);
            entity.Property(e => e.Filename).HasMaxLength(200);
            entity.Property(e => e.MessageGuid).HasColumnName("MessageGUID");
            entity.Property(e => e.MimeType).HasMaxLength(50);
        });

        modelBuilder.Entity<AuthorizationToken>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("AuthorizationToken");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.AccountGuid).HasColumnName("AccountGUID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("Comment");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.AuthorGuid).HasColumnName("AuthorGUID");
            entity.Property(e => e.Body).HasMaxLength(1000);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.MessageGuid).HasColumnName("MessageGUID");

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Account");

            entity.HasOne(d => d.Message).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MessageGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Message");
        });

        modelBuilder.Entity<ContactList>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("ContactList");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.MainUserGuid).HasColumnName("MainUserGUID");
            entity.Property(e => e.SecondaryUserGuid).HasColumnName("SecondaryUserGUID");
        });

        modelBuilder.Entity<ContactListRequest>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("ContactListRequest");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Created)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ReceiverGuid).HasColumnName("ReceiverGUID");
            entity.Property(e => e.RequestStatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.SenderGuid).HasColumnName("SenderGUID");
        });

        modelBuilder.Entity<GroupDict>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("GroupDict");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.GroupName).HasMaxLength(255);
            entity.Property(e => e.GroupOwnerGuid).HasColumnName("GroupOwnerGUID");
            entity.Property(e => e.GroupTypeGuid).HasColumnName("GroupTypeGUID");

            entity.HasOne(d => d.GroupType).WithMany(p => p.GroupDicts)
                .HasForeignKey(d => d.GroupTypeGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupDict_GroupType");
        });

        modelBuilder.Entity<GroupRole>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("GroupRole");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupType>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("GroupType");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("Message");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.AuthorGuid).HasColumnName("AuthorGUID");
            entity.Property(e => e.Created).HasPrecision(3);
            entity.Property(e => e.Edited).HasPrecision(3);
            entity.Property(e => e.GroupGuid).HasColumnName("GroupGUID");
            entity.Property(e => e.ReceiverGuid).HasColumnName("ReceiverGUID");
            entity.Property(e => e.ReplyMessageGuid).HasColumnName("ReplyMessageGUID");

            entity.HasOne(d => d.Author).WithMany(p => p.MessageAuthors)
                .HasForeignKey(d => d.AuthorGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Author");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverGuid)
                .HasConstraintName("FK_Receiver");
        });

        modelBuilder.Entity<Message2Account>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("Message2Account");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.AccountGuid).HasColumnName("AccountGUID");
            entity.Property(e => e.MessageGuid).HasColumnName("MessageGUID");
        });

        modelBuilder.Entity<UserGroupRole>(entity =>
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("UserGroupRole");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("GUID");
            entity.Property(e => e.AccountGuid).HasColumnName("AccountGUID");
            entity.Property(e => e.GroupGuid).HasColumnName("GroupGUID");
            entity.Property(e => e.GroupRoleGuid).HasColumnName("GroupRoleGUID");

            entity.HasOne(d => d.Account).WithMany(p => p.UserGroupRoles)
                .HasForeignKey(d => d.AccountGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserGroupRole_Account");

            entity.HasOne(d => d.Group).WithMany(p => p.UserGroupRoles)
                .HasForeignKey(d => d.GroupGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserGroupRole_GroupDict");
        });
        modelBuilder.HasSequence<int>("SeqOrderIDs")
            .HasMin(1L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
