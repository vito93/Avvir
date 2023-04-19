﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Avvir.DataLayer.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AvvirModel : DbContext
    {
        public AvvirModel()
            : base("name=AvvirModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<GroupDict> GroupDict { get; set; }
        public virtual DbSet<GroupType> GroupType { get; set; }
        public virtual DbSet<UserGroupRole> UserGroupRole { get; set; }
        public virtual DbSet<AccountAuthorization> AccountAuthorization { get; set; }
        public virtual DbSet<AccountConfirmationToken> AccountConfirmationToken { get; set; }
        public virtual DbSet<AttachmentBody> AttachmentBody { get; set; }
        public virtual DbSet<AttachmentHeader> AttachmentHeader { get; set; }
        public virtual DbSet<AuthorizationToken> AuthorizationToken { get; set; }
        public virtual DbSet<ContactListRequest> ContactListRequest { get; set; }
        public virtual DbSet<GroupRole> GroupRole { get; set; }
        public virtual DbSet<Message2Account> Message2Account { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<ContactList> ContactList { get; set; }
        public virtual DbSet<Message> Message { get; set; }
    
        public virtual int AssignUserRole(Nullable<System.Guid> accountGUID, string groupGUID, Nullable<System.Guid> groupRoleGUID)
        {
            var accountGUIDParameter = accountGUID.HasValue ?
                new ObjectParameter("AccountGUID", accountGUID) :
                new ObjectParameter("AccountGUID", typeof(System.Guid));
    
            var groupGUIDParameter = groupGUID != null ?
                new ObjectParameter("GroupGUID", groupGUID) :
                new ObjectParameter("GroupGUID", typeof(string));
    
            var groupRoleGUIDParameter = groupRoleGUID.HasValue ?
                new ObjectParameter("GroupRoleGUID", groupRoleGUID) :
                new ObjectParameter("GroupRoleGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AssignUserRole", accountGUIDParameter, groupGUIDParameter, groupRoleGUIDParameter);
        }
    
        public virtual int CheckConfirmationToken(Nullable<System.Guid> accountGUID, Nullable<System.Guid> confirmationToken)
        {
            var accountGUIDParameter = accountGUID.HasValue ?
                new ObjectParameter("AccountGUID", accountGUID) :
                new ObjectParameter("AccountGUID", typeof(System.Guid));
    
            var confirmationTokenParameter = confirmationToken.HasValue ?
                new ObjectParameter("ConfirmationToken", confirmationToken) :
                new ObjectParameter("ConfirmationToken", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckConfirmationToken", accountGUIDParameter, confirmationTokenParameter);
        }
    
        public virtual int CreateGroupOrChannel(Nullable<System.Guid> creatorGUID, string newName, Nullable<System.Guid> groupTypeGUID)
        {
            var creatorGUIDParameter = creatorGUID.HasValue ?
                new ObjectParameter("CreatorGUID", creatorGUID) :
                new ObjectParameter("CreatorGUID", typeof(System.Guid));
    
            var newNameParameter = newName != null ?
                new ObjectParameter("NewName", newName) :
                new ObjectParameter("NewName", typeof(string));
    
            var groupTypeGUIDParameter = groupTypeGUID.HasValue ?
                new ObjectParameter("GroupTypeGUID", groupTypeGUID) :
                new ObjectParameter("GroupTypeGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateGroupOrChannel", creatorGUIDParameter, newNameParameter, groupTypeGUIDParameter);
        }
    
        public virtual int CreateUser(string name, string passwordHash, string email)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var passwordHashParameter = passwordHash != null ?
                new ObjectParameter("PasswordHash", passwordHash) :
                new ObjectParameter("PasswordHash", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUser", nameParameter, passwordHashParameter, emailParameter);
        }
    
        public virtual ObjectResult<Nullable<System.Guid>> GetAuthrizationToken(Nullable<System.Guid> accountGUID)
        {
            var accountGUIDParameter = accountGUID.HasValue ?
                new ObjectParameter("AccountGUID", accountGUID) :
                new ObjectParameter("AccountGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("GetAuthrizationToken", accountGUIDParameter);
        }
    
        public virtual int GetChatMessages(Nullable<System.Guid> account1GUID, Nullable<System.Guid> account2GUID)
        {
            var account1GUIDParameter = account1GUID.HasValue ?
                new ObjectParameter("Account1GUID", account1GUID) :
                new ObjectParameter("Account1GUID", typeof(System.Guid));
    
            var account2GUIDParameter = account2GUID.HasValue ?
                new ObjectParameter("Account2GUID", account2GUID) :
                new ObjectParameter("Account2GUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetChatMessages", account1GUIDParameter, account2GUIDParameter);
        }
    
        public virtual int GetGroupMessages(Nullable<System.Guid> groupGUID)
        {
            var groupGUIDParameter = groupGUID.HasValue ?
                new ObjectParameter("GroupGUID", groupGUID) :
                new ObjectParameter("GroupGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetGroupMessages", groupGUIDParameter);
        }
    
        public virtual int SaveComment(Nullable<System.Guid> authorGUID, Nullable<System.Guid> messageGUID, string commentBody)
        {
            var authorGUIDParameter = authorGUID.HasValue ?
                new ObjectParameter("AuthorGUID", authorGUID) :
                new ObjectParameter("AuthorGUID", typeof(System.Guid));
    
            var messageGUIDParameter = messageGUID.HasValue ?
                new ObjectParameter("MessageGUID", messageGUID) :
                new ObjectParameter("MessageGUID", typeof(System.Guid));
    
            var commentBodyParameter = commentBody != null ?
                new ObjectParameter("CommentBody", commentBody) :
                new ObjectParameter("CommentBody", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveComment", authorGUIDParameter, messageGUIDParameter, commentBodyParameter);
        }
    
        public virtual int SaveContactListRequest(Nullable<System.Guid> senderGUID, Nullable<System.Guid> receiverGUID)
        {
            var senderGUIDParameter = senderGUID.HasValue ?
                new ObjectParameter("SenderGUID", senderGUID) :
                new ObjectParameter("SenderGUID", typeof(System.Guid));
    
            var receiverGUIDParameter = receiverGUID.HasValue ?
                new ObjectParameter("ReceiverGUID", receiverGUID) :
                new ObjectParameter("ReceiverGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveContactListRequest", senderGUIDParameter, receiverGUIDParameter);
        }
    
        public virtual int SaveFile(Nullable<System.Guid> messageGUID, string mimeType, string filename, byte[] attachmentBody)
        {
            var messageGUIDParameter = messageGUID.HasValue ?
                new ObjectParameter("MessageGUID", messageGUID) :
                new ObjectParameter("MessageGUID", typeof(System.Guid));
    
            var mimeTypeParameter = mimeType != null ?
                new ObjectParameter("MimeType", mimeType) :
                new ObjectParameter("MimeType", typeof(string));
    
            var filenameParameter = filename != null ?
                new ObjectParameter("Filename", filename) :
                new ObjectParameter("Filename", typeof(string));
    
            var attachmentBodyParameter = attachmentBody != null ?
                new ObjectParameter("AttachmentBody", attachmentBody) :
                new ObjectParameter("AttachmentBody", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveFile", messageGUIDParameter, mimeTypeParameter, filenameParameter, attachmentBodyParameter);
        }
    
        public virtual int SaveMessage(Nullable<System.Guid> authorGUID, Nullable<System.Guid> receiverGUID, Nullable<System.Guid> groupGUID, Nullable<System.Guid> replyMessageGUID, string messageBody)
        {
            var authorGUIDParameter = authorGUID.HasValue ?
                new ObjectParameter("AuthorGUID", authorGUID) :
                new ObjectParameter("AuthorGUID", typeof(System.Guid));
    
            var receiverGUIDParameter = receiverGUID.HasValue ?
                new ObjectParameter("ReceiverGUID", receiverGUID) :
                new ObjectParameter("ReceiverGUID", typeof(System.Guid));
    
            var groupGUIDParameter = groupGUID.HasValue ?
                new ObjectParameter("GroupGUID", groupGUID) :
                new ObjectParameter("GroupGUID", typeof(System.Guid));
    
            var replyMessageGUIDParameter = replyMessageGUID.HasValue ?
                new ObjectParameter("ReplyMessageGUID", replyMessageGUID) :
                new ObjectParameter("ReplyMessageGUID", typeof(System.Guid));
    
            var messageBodyParameter = messageBody != null ?
                new ObjectParameter("MessageBody", messageBody) :
                new ObjectParameter("MessageBody", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveMessage", authorGUIDParameter, receiverGUIDParameter, groupGUIDParameter, replyMessageGUIDParameter, messageBodyParameter);
        }
    
        public virtual int SendUserConfirmationMail(Nullable<System.Guid> accountGUID)
        {
            var accountGUIDParameter = accountGUID.HasValue ?
                new ObjectParameter("AccountGUID", accountGUID) :
                new ObjectParameter("AccountGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SendUserConfirmationMail", accountGUIDParameter);
        }
    
        public virtual int UpdateContactListRequest(Nullable<System.Guid> requestGUID, Nullable<byte> newStatus)
        {
            var requestGUIDParameter = requestGUID.HasValue ?
                new ObjectParameter("RequestGUID", requestGUID) :
                new ObjectParameter("RequestGUID", typeof(System.Guid));
    
            var newStatusParameter = newStatus.HasValue ?
                new ObjectParameter("NewStatus", newStatus) :
                new ObjectParameter("NewStatus", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateContactListRequest", requestGUIDParameter, newStatusParameter);
        }
    }
}