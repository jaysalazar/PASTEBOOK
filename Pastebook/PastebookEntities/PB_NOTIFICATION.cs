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
    
    public partial class PB_NOTIFICATION
    {
        public int ID { get; set; }
        public int RECEIVER_ID { get; set; }
        public int SENDER_ID { get; set; }
        public string NOTIF_TYPE { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public Nullable<int> COMMENT_ID { get; set; }
        public Nullable<int> POST_ID { get; set; }
        public string SEEN { get; set; }
    
        public virtual PB_COMMENT PB_COMMENT { get; set; }
        public virtual PB_POST PB_POST { get; set; }
        public virtual PB_USER PB_USER { get; set; }
        public virtual PB_USER PB_USER1 { get; set; }
    }
}
