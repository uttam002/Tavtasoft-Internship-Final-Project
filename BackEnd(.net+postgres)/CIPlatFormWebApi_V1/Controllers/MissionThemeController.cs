using Business_Logic_Layer.MissionTheme;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController : ControllerBase
    {
        private readonly MissionTheme _missionTheme;

        public MissionThemeController(MissionTheme missionTheme)
        {
            _missionTheme = missionTheme;
        }

        [HttpGet]
        [Route("GetMissionThemes")]
        public async Task<IActionResult> GetMissionThemes()
        {
            try
            {
                var themes = await _missionTheme.GetMissionThemes();
                if(themes == null)
                {
                    return NotFound();
                }
                return Ok(themes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("CreateMissionTheme")]
        public async Task<IActionResult> CreateMissionTheme([FromBody] Data_Logic_Layer.MissionThemeEntity.MissionTheme model)
        {
            try
            {
                var result = await _missionTheme.CreateMissionTheme(model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateMissionTheme/{missionThemeId}")]
        public async Task<IActionResult> UpdateMissionTheme(int missionThemeId, [FromBody] Data_Logic_Layer.MissionThemeEntity.MissionTheme model)
        {
            if (missionThemeId <= 0)
            {
                return BadRequest("Invalid Mission Theme ID");
            }

            try
            {
                var result = await _missionTheme.UpdateMissionTheme(missionThemeId, model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetMissionThemeById/{missionThemeId}")]
        public async Task<IActionResult> GetMissionThemeById(int missionThemeId)
        {
            if (missionThemeId <= 0)
            {
                return BadRequest("Invalid Mission Theme ID");
            }

            try
            {
                var theme = await _missionTheme.GetMissionThemeById(missionThemeId);
                if (theme == null)
                {
                    return NotFound();
                }
                return Ok(theme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeleteMissionTheme/{id}")]
        public async Task<IActionResult> DeleteMissionTheme(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Mission Theme ID");
            }

            try
            {
                var result = await _missionTheme.DeleteMissionTheme(id);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
