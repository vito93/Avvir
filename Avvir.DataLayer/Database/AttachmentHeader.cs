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
    
    public partial class AttachmentHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttachmentHeader()
        {
            this.AttachmentBody = new HashSet<AttachmentBody>();
        }
    
        public System.Guid GUID { get; set; }
        public string Filename { get; set; }
        public string MimeType { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.Guid> MessageGUID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttachmentBody> AttachmentBody { get; set; }
    }
}