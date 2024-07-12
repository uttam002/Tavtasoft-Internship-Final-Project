using Business_Logic_Layer.MissionSkill;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController : ControllerBase
    {
        private readonly MissionSkill _missionSkill;

        public MissionSkillController(MissionSkill missionSkill)
        {
            _missionSkill = missionSkill;
        }

        [HttpGet]
        [Route("GetMissionSkill")]
        public async Task<IActionResult> GetMissionSkill()
        {
            try
            {
                var skillExist = await _missionSkill.GetMissionSkill();
                if (skillExist == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(skillExist);
                }
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
        }

        [HttpPost]
        [Route("CreateMissionSkill")]
        public async Task<IActionResult> CreateMissionSkill([FromBody] Data_Logic_Layer.MissionSkillEntity.MissionSkill model)
        { 
            try
            {
                var result = await _missionSkill.CreateMissionSkill(model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateMissionSkill/{missionSkillId}")]
        public async Task<IActionResult> UpdateMissionSkill(int missionSkillId, [FromBody] Data_Logic_Layer.MissionSkillEntity.MissionSkill model)
        {
            if (missionSkillId <= 0)
            {
                return BadRequest("Invalid Mission Skill ID");
            }

            try
            {
                var result = await _missionSkill.UpdateMissionSkill(missionSkillId, model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetMissioSkillById/{missionSkillId}")]
        public async Task<IActionResult> GetMissionSkillById(int missionSkillId)
        {
            if (missionSkillId <= 0)
            {
                return BadRequest("Invalid Mission Skill ID");
            }

            try
            {
                var skillExist = await _missionSkill.GetMissionSkillById(missionSkillId);
                if (skillExist == null)
                {
                    return NotFound();
                }
                return Ok(skillExist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeleteMissionSkill/{id}")]
        public async Task<IActionResult> DeleteMissionSkill(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Mission Skill ID");
            }

            try
            {
                var result = await _missionSkill.DeleteMissionSkill(id);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
