//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class AccountAuthorization
    {
        public System.Guid GUID { get; set; }
        public System.Guid AccountGUID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ValidTo { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
