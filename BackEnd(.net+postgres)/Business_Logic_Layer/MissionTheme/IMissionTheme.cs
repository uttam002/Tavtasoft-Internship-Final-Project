using Data_Logic_Layer.MissionThemeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.MissionTheme
{
    public interface IMissionTheme
    {
        Task<List<Data_Logic_Layer.MissionThemeEntity.MissionTheme>> GetMissionThemes();
        Task<string> CreateMissionTheme(Data_Logic_Layer.MissionThemeEntity.MissionTheme model);
        Task<string> UpdateMissionTheme(int missionThemeId, Data_Logic_Layer.MissionThemeEntity.MissionTheme model);
        Task<Data_Logic_Layer.MissionThemeEntity.MissionTheme> GetMissionThemeById(int missionThemeId);
        Task<string> DeleteMissionTheme(int id);

    }
}
