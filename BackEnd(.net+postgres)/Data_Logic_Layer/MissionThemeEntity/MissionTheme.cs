using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.MissionThemeEntity
{
    public class MissionTheme : BaseEntity
    {
        [Key]
        public int ThemeId { get; set; }
        public string? ThemeName { get; set; }
        public string? ThemeDescription { get; set; }
        public string? ThemeImage { get; set; }

        // Add any other properties as needed
    }
}
