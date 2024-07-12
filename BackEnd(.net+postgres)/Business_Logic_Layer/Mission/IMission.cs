using Data_Logic_Layer.MissionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Mission
{
    public interface IMission
    {
        Task<List<MissionViewModel>> GetMissionsWithDetails();
        Task<string> CreateMission(MissionDetails model);
        Task<MissionViewModel> GetMissionDetailsById(int missionId);

        Task<string> DeleteMission(int id);
        Task<string> UpdateMission(MissionDetails model,int missionId);
    }
}
