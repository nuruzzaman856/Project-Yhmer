using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Areas.Identity.Data;
using Api.Areas.Identity.Data.Entities;
using Api.Data;
using Api.Data.Entities;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Api.Areas.Identity.Data.User;

namespace Api.Areas.Identity.Data
{
    public class Context : IdentityDbContext<User>
    {
        //private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ApiDB;Trusted_Connection=True;";

        //public DbSet<DemoTable> DemoTable { get; set; }

        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<UserGDPR> UserGDPR { get; set; }
        //public DbSet<Appointment> Appointments { get; set; }
        //public DbSet<AppointmentParticipant> AppointmentParticipants { get; set; }
        //public DbSet<Chat> Chats { get; set; }
        //public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationStudent> EducationStudent { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Content> Content { get; set; }
        //public DbSet<Experience> Experiences { get; set; }

        ///// <summary>
        /////  lol 
        ///// </summary>
        ///// 
        //public DbSet<Job> Job { get; set; }
        //public DbSet<Job> Jobs { get; set; }
        //public DbSet<JobSkill> JobSkills { get; set; }
        //public DbSet<Message> Messages { get; set; }
        //public DbSet<Post> Posts { get; set; }
        //public DbSet<Rating> Ratings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillMatch> SkillMatches { get; set; }
        public DbSet<StudentSearchProfile> StudentSearchProfiles { get; set; }
        public DbSet<SearchProfile> SearchProfiles { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<MatchManager> MatchManager { get; set; }

        public DbSet<SearchProfileSkillMatch> SearchProfileSkillMatches { get; set; }
        //public DbSet<Study> Studies { get; set; }
        //public DbSet<UserSpecification> UserSpecifications { get; set; }

        public Context(DbContextOptions<Context> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string adminId = "admin-c0-aa65-4af8-bd17-00bd9344e575";
            const string roleId = "root-0c0-aa65-4af8-bd17-00bd9344e575";
            const string studentRoleId = "user-2c0-aa65-4af8-bd17-00bd9344e575";
            const string companyRoleId = "comp-2c0-aa65-4af8-bd17-00bd9344e575";
            const string organizerRoleId = "orga-2c0-aa65-4af8-bd17-00bd9344e575";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "root",
                NormalizedName = "ROOT"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = studentRoleId,
                Name = "student",
                NormalizedName = "STUDENT"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = companyRoleId,
                Name = "company",
                NormalizedName = "COMPANY"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = organizerRoleId,
                Name = "organizer",
                NormalizedName = "ORGANIZER"
            });

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@core.api",
                NormalizedEmail = "ADMIN@CORE.API",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "AdminPass1!"),
                SecurityStamp = Guid.NewGuid().ToString(),
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });

            builder.Entity<Education>()
                .HasIndex(u => u.RegisterCode)
                .IsUnique();
        }
    }
}
