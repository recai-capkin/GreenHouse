namespace GreenHouse.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int NotificationId { get; set; }

        public int? UserId { get; set; }

        public string NotificationContent { get; set; }

        public virtual User User { get; set; }
    }
}
