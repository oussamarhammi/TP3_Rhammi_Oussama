using JuliePro_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Data
{
    public class JulieProDbContext : DbContext
    {
        public JulieProDbContext(DbContextOptions<JulieProDbContext> options) : base(options) { }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Objective> Objectives { get; set; }

        public DbSet<ScheduledSession> ScheduledSessions { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<TrainingEquipment> TrainingEquipments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Certification> Certifications { get; set; }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
    



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainingEquipment>().HasKey(te => new { te.Training_Id, te.Equipment_Id });
            modelBuilder.Entity<TrainerCertification>().HasKey(tr => new { tr.Trainer_Id, tr.Certification_Id });

            //Générer des données de départ
            modelBuilder.GenerateData();
    }
  }
}
