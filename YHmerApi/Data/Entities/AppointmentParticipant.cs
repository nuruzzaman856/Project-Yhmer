using Api.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Areas.Identity.Data.Entities
{
    [Table("AppointmentParticipants")]
    public class AppointmentParticipant
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public User User { get; set; }
        [ForeignKey("ID")]
        public Appointment Appointment { get; set; }
        public string Reminder { get; set; }

        public AppointmentParticipant()
        {
           
            Reminder = String.Empty;
            ID = Guid.NewGuid().ToString();
        }

    }
}
