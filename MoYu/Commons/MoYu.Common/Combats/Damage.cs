using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Combats
{
  public class Damage
  {
    public static Damage New(ITarget attacker, BigInteger damagePoint, EnumDamageType? type = null)
    {
      return new Damage(attacker, damagePoint, type);
    }
    public Damage()
    {

    }
    public Damage(ITarget attacker, BigInteger damagePoint, EnumDamageType? type = null)
    {
      this.DamagePoint = damagePoint;
      this.DamageType = type.HasValue ? type.Value : EnumDamageType.Physic;
      this.Attacker = attacker;
    }
    public ITarget Attacker { get; set; }
    public BigInteger DamagePoint { get; set; }
    public EnumDamageType DamageType { get; set; }
  }
}
