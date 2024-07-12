using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.MissionEntity
{
    public class MissionDetails : BaseEntity
    {
        [Key]
        public int MissionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Introduction { get; set; }
        public string? Challenge { get; set; }
        public int? TotalSeats { get; set; }
        public int? SeatsLeft { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? ThemeId { get; set; }
        public int? OrganizationId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public string? MissionImage { get; set; }

        public int? MissionType { get; set; }
        public string? MissionObject { get; set; }
        public int? MissionAchieved { get; set; }
    }

    public class MissionViewModel : BaseEntity
    {
        public int MissionId { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string Challenge { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Deadline { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string ThemeName { get; set; }
        public string OrganizationName { get; set; }
        public int? Rating { get; set; }
        public int? SeatsLeft { get; set; }
        public string ImageURL { get; set; }
        public int? MissionType { get; set; }
        public string? MissionObject { get; set; }
        public int? MissionAchieved { get; set; }
    }
}
