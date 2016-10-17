//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PastebookDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PB_USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PB_USER()
        {
            this.PB_COMMENT = new HashSet<PB_COMMENT>();
            this.PB_FRIEND = new HashSet<PB_FRIEND>();
            this.PB_FRIEND1 = new HashSet<PB_FRIEND>();
            this.PB_LIKE = new HashSet<PB_LIKE>();
            this.PB_NOTIFICATION = new HashSet<PB_NOTIFICATION>();
            this.PB_NOTIFICATION1 = new HashSet<PB_NOTIFICATION>();
            this.PB_POST = new HashSet<PB_POST>();
            this.PB_POST1 = new HashSet<PB_POST>();
        }
    
        public int ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string SALT { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public Nullable<System.DateTime> BIRTHDAY { get; set; }
        public Nullable<int> COUNTRY_ID { get; set; }
        public string MOBILE_NO { get; set; }
        public string GENDER { get; set; }
        public byte[] PROFILE_PIC { get; set; }
        public Nullable<System.DateTime> DATE_CREATED { get; set; }
        public string ABOUT_ME { get; set; }
        public string EMAIL_ADDRESS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_COMMENT> PB_COMMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_FRIEND> PB_FRIEND { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_FRIEND> PB_FRIEND1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_LIKE> PB_LIKE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_NOTIFICATION> PB_NOTIFICATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_NOTIFICATION> PB_NOTIFICATION1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_POST> PB_POST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PB_POST> PB_POST1 { get; set; }
        public virtual REF_COUNTRY REF_COUNTRY { get; set; }
    }
}
