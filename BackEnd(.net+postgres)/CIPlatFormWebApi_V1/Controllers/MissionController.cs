using Business_Logic_Layer.Mission;
using Data_Logic_Layer.MissionEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly Mission _missionRepository;

        public MissionController(Mission missionRepository)
        {
            _missionRepository = missionRepository;

        }
        [HttpPost("CreateMission")]
       // [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateMission([FromBody] MissionDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mission = await _missionRepository.CreateMission(model);

            return Ok(mission);
        }

        [HttpGet("GetMissions")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetMissionWithDetails()
        {
            var missionWithDetails = await _missionRepository.GetMissionsWithDetails();
            return Ok(missionWithDetails);
        }


        [HttpGet("GetMissionById/{MissionId}")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetMissionWithDetailsById(int MissionId)
        {
            var missionWithDetails = await _missionRepository.GetMissionDetailsById(MissionId);
            return Ok(missionWithDetails);
        }

        [HttpDelete("{id}")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var result = await _missionRepository.DeleteMission(id);

            if (result == "Mission not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMission(int id ,[FromBody] MissionDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mission = await _missionRepository.UpdateMission(model,id);

            return Ok(mission);
        }

    }
}
