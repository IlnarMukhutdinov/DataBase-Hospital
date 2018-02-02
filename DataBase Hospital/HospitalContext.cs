using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataBase_Hospital
{
    class HospitalContext : DbContext
    {
        public HospitalContext() : base("Hospital") { }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Shedule> Shedules { get; set; }

        public DbSet<Cabinet> Cabinets { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
