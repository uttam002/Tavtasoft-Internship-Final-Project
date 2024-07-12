using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.MissionSkillEntity
{
    public class MissionSkill:BaseEntity
    {
        [Key]
        public int SkilllId { get; set; }
        public string SkillName { get; set; }
        public bool Status { get; set; }
    }
}
