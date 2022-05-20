using MoYu.Common.Combats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Skills
{
  public class SkillBase
  {
    public string Name { get; set; }
    public EnumSkillType SkillType { get; set; }
    public int Cost { get; set; }

  }
}
