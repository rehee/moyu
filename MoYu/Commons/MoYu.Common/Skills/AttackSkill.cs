using MoYu.Common.Combats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Skills
{
  public class AttackSkill : SkillBase
  {
    public static AttackSkill NormalAttack()
    {
      return new AttackSkill()
      {
        DamageType = null,
        SkillType = EnumSkillType.AttackSkill,
        Name = GeneralSkills.DefaultAttackSkilName
      };
    }
    public EnumDamageType? DamageType { get; set; }
    public decimal DamageModify { get; set; }
    public decimal HitModify { get; set; }
    public decimal AttackSpeedModify { get; set; }
  }


}
