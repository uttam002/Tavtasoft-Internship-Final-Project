using Data_Logic_Layer.MissionEntity;
using Data_Logic_Layer.MissionSkillEntity;
using Data_Logic_Layer.MissionThemeEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User>  User { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<MissionDetails> Mission {  get; set; }
        public DbSet<MissionTheme> MissionTheme { get; set; }
        public DbSet<MissionSkill> MissionSkills { get; set; }
    }
}
