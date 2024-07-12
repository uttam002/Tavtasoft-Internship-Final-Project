using Data_Logic_Layer.Entity;
using Data_Logic_Layer.MissionSkillEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.MissionSkill
{
    public class MissionSkill:IMissionSkill
    {
        private readonly AppDbContext _context;
        public MissionSkill(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<List<Data_Logic_Layer.MissionSkillEntity.MissionSkill>> GetMissionSkill()
        {
            return await _context.MissionSkills.ToListAsync();
        }
        public async Task<string> CreateMissionSkill(Data_Logic_Layer.MissionSkillEntity.MissionSkill model)
        {
            await _context.MissionSkills.AddAsync(model);
            await _context.SaveChangesAsync();
            return "Mission Skill Created Successfully";
        }
        public async Task<string> UpdateMissionSkill(int missionSkillId, Data_Logic_Layer.MissionSkillEntity.MissionSkill model)
        {
            var skillExist = await _context.MissionSkills.FindAsync(missionSkillId);
            if (skillExist != null)
            {
                skillExist.SkillName = model.SkillName;
                skillExist.Status = model.Status;
                skillExist.ModifiedDate = DateTime.UtcNow;

                 _context.MissionSkills.Update(skillExist);
                await _context.SaveChangesAsync();
                return "Skill Updated Successsfully";
            }
            else
            {
                return "Skill Not found";
            }
        }
        public async Task<Data_Logic_Layer.MissionSkillEntity.MissionSkill> GetMissionSkillById(int missionSkillId)
        {
            var skillExist = await _context.MissionSkills.FindAsync(missionSkillId);
            if (skillExist != null)
            {
                return skillExist;
            }
            else
            {
                return null;
            }
        }
        public async Task<string> DeleteMissionSkill(int id)
        {
            var skillExist = await _context.MissionSkills.FindAsync(id);
            if (skillExist != null)
            {
                skillExist.IsDeleted = true;
                await _context.SaveChangesAsync();
                return "Mission Deleted Successfully";
            }
            else
            {
                return "Mission not Found";
            }
        }
    }
}
