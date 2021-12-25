
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCSharp.Comum
{
    public class Base : Notifiable<Notification>
    {
        public Base()
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime Data { get; set; }
    }
}
