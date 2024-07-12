using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.MissionSkill
{
    public interface IMissionSkill
    {
        Task<List<Data_Logic_Layer.MissionSkillEntity.MissionSkill>> GetMissionSkill();
        Task<string> CreateMissionSkill(Data_Logic_Layer.MissionSkillEntity.MissionSkill model);
        Task<string> UpdateMissionSkill(int missionSkillId, Data_Logic_Layer.MissionSkillEntity.MissionSkill model);
        Task<Data_Logic_Layer.MissionSkillEntity.MissionSkill> GetMissionSkillById(int missionSkillId);
        Task<string> DeleteMissionSkill(int id); 
    }
}
