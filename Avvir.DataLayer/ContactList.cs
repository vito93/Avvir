//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Avvir.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactList
    {
        public System.Guid GUID { get; set; }
        public System.Guid ContactListOwner { get; set; }
        public System.Guid AccountInListGUID { get; set; }
        public bool IsApproved { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Account Account1 { get; set; }
    }
}
