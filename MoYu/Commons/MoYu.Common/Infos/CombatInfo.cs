using MoYu.Common.Combats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Infos
{
  public class CombatInfo : InfomationBase
  {
    public static CombatInfo New(ITarget attacker, ITarget target, string attackName, EnumAttackResult result, BigInteger? damage = null)
    {
      return new CombatInfo()
      {
        InfoType = EnumInfoType.Combat,
        Time = DateTime.Now,
        From = attacker.Id,
        To = target.Id,
        Message = $"{attacker.Name} {attackName} {target.Name} {result.ToString()}, deals {(damage != null ? damage.Value.ToString() : "0")} damage"
      };
    }


  }
}
