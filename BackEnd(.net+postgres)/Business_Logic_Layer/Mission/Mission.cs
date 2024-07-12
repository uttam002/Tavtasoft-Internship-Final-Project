using Data_Logic_Layer.Entity;
using Data_Logic_Layer.MissionEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Mission
{
    public class Mission: IMission
    {
        private readonly AppDbContext _dbcontext;

        public Mission(AppDbContext DbContext)
        {
            _dbcontext = DbContext;
        }

        public async Task<List<MissionViewModel>> GetMissionsWithDetails()
        {
            try
            {

                var missionsWithDetails = await _dbcontext.Mission.Where(mission=> !mission.IsDeleted).Select(mission => new MissionViewModel
                {
                    MissionId = mission.MissionId,
                    MissionTitle = mission.Title,
                    MissionDescription = mission.Description,
                    // CityName = _authContext.Cities.FirstOrDefault(c => c.CityId == mission.CityId).CityName,
                    //CountryName = _authContext.Countries.FirstOrDefault(c => c.CountryId == mission.CountryId).CountryName,
                    StartDate = mission.StartDate.ToString(),
                    EndDate = mission.EndDate.ToString(),
                    Deadline = mission.Deadline.ToString()
                }).ToListAsync();

                return missionsWithDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateMission(MissionDetails model)
        {
            try{
                var mission = new MissionDetails
                {
                    Title = model.Title,
                    Description = model.Description,
                    Introduction = model.Introduction,
                    Challenge = model.Challenge,
                    TotalSeats = model.TotalSeats,
                    SeatsLeft = model.SeatsLeft,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Deadline = model.Deadline,
                    ThemeId = model.ThemeId,
                    OrganizationId = model.OrganizationId,
                    CityId = model.CityId,
                    CountryId = model.CountryId,
                    MissionImage = model.MissionImage,
                    MissionType = model.MissionType,
                    MissionObject = model.MissionObject,
                    MissionAchieved = model.MissionAchieved,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _dbcontext.Mission.Add(mission);
                await _dbcontext.SaveChangesAsync();

                return "Mission Created Succesfully";
            }
            catch(Exception ex)
            {
                return  ex.ToString();
            }
        }

        public async Task<MissionViewModel> GetMissionDetailsById(int missionId)
        {
           try{    
                var missionWithDetails = await _dbcontext.Mission
                    .Where(mission => mission.MissionId == missionId && !mission.IsDeleted)
                    .Select(mission => new MissionViewModel
                    {
                        MissionId = mission.MissionId,
                        MissionTitle = mission.Title,
                        MissionDescription = mission.Description,
                        // CityName = _authContext.Cities.FirstOrDefault(c => c.CityId == mission.CityId).CityName,
                        // CountryName = _authContext.Countries.FirstOrDefault(c => c.CountryId == mission.CountryId).CountryName,
                        StartDate = mission.StartDate.ToString(),
                        EndDate = mission.EndDate.ToString(),
                        Deadline = mission.Deadline.ToString(),
                        SeatsLeft = mission.SeatsLeft,
                        //   OrganizationName = _authContext.Organizations.FirstOrDefault(r => r.OrganizationId == mission.OrganizationId).OrganizationName,
                        ////   Rating = _authContext.Organizations.FirstOrDefault(r => r.OrganizationId == mission.OrganizationId).Rating,
                        //  ImageURL = _authContext.MissionImage.FirstOrDefault(i => i.MissionId == mission.MissionId).ImageURL,
                        //   ThemeName = _authContext.MissionThemes.FirstOrDefault(t => t.ThemeId == mission.ThemeId).ThemeName,
                        Challenge = mission.Challenge,
                        MissionType = mission.MissionType,
                        MissionObject = mission.MissionObject,
                        MissionAchieved = mission.MissionAchieved,
                        IsDeleted = mission.IsDeleted,


                    })
                    .FirstOrDefaultAsync();

                return missionWithDetails;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteMission(int id)
        {
            try{    var mission = await _dbcontext.Mission.FindAsync(id);
                if (mission == null)
                {
                    return "Mission not found";
                }

                mission.IsDeleted = true;
                await _dbcontext.SaveChangesAsync();

                return "Mission Deleted Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<string> UpdateMission(MissionDetails model,int id)
        {
            try
            {
                if (model.MissionId != id)
                {
                    return "You Can't Change Mission Id";
                }
                var missionExist = await _dbcontext.Mission
                   .Where(mission => mission.MissionId == model.MissionId).FirstOrDefaultAsync();

                if (missionExist != null)
                {
                    missionExist.Title = model.Title;
                    missionExist.Description = model.Description;
                    missionExist.Introduction = model.Introduction;
                    missionExist.Challenge = model.Challenge;
                    missionExist.TotalSeats = model.TotalSeats;
                    missionExist.SeatsLeft = model.SeatsLeft;
                    missionExist.StartDate = model.StartDate;
                    missionExist.EndDate = model.EndDate;
                    missionExist.Deadline = model.Deadline;
                    missionExist.ThemeId = model.ThemeId;
                    missionExist.OrganizationId = model.OrganizationId;
                    missionExist.CityId = model.CityId;
                    missionExist.CountryId = model.CountryId;
                    missionExist.MissionImage = model.MissionImage;
                    missionExist.MissionObject = model.MissionObject;
                    missionExist.MissionAchieved = model.MissionAchieved;
                    missionExist.ModifiedDate = DateTime.UtcNow;

                    _dbcontext.Mission.Update(missionExist);
                    await _dbcontext.SaveChangesAsync();

                    return "Mission Updated Succesfully";
                }
                else
                {
                    return "Mission Not Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
