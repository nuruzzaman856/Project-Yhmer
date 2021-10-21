using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Api.Areas.Identity.Data;


namespace Api.Areas.Identity.Data.Entities
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        public string ID { get; set; } 
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public string InvitationLink { get; set; }
        public double Duration { get; set; }
        public int CreatedByUserID  { get; set; }
        public virtual List<AppointmentParticipant> AppointmentParticipants { get; set; } 


        public Appointment()
        {
            Title = String.Empty;
            Location = String.Empty;
            StartDate = default;
            InvitationLink = String.Empty;
            AppointmentParticipants = new List<AppointmentParticipant>();
            ID = Guid.NewGuid().ToString();
        }
        //Appointment kan ha många participants?
    }
}
