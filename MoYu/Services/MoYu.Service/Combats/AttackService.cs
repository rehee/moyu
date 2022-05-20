using MoYu.Common.Combats;
using MoYu.Common.Infos;
using MoYu.Common.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Service.Combats
{
  public class AttackService : IAttackService
  {
    private Random rnd;
    public AttackService()
    {
      rnd = new Random();
    }
    public RequestResponse<IInfo> Attack(ITarget attacker, ITarget target)
    {
      var result = new RequestResponse<IInfo>();

      var hit = AttackCheck(attacker, target);
      if (!hit)
      {
        result.SetSuccess(CombatInfo.New(attacker, target, "NormalAttack", EnumAttackResult.Miss));
        return result;
      }

      var parried = ParryCheck(target);
      if (parried)
      {
        result.SetSuccess(CombatInfo.New(attacker, target, "NormalAttack", EnumAttackResult.Parry));
        return result;
      }

      var dodged = DodgeCheck(target);
      if (dodged)
      {
        result.SetSuccess(CombatInfo.New(attacker, target, "NormalAttack", EnumAttackResult.Dodge));
        return result;
      }
      var blocked = BlockCheck(target);
      if (blocked)
      {
        result.SetSuccess(CombatInfo.New(attacker, target, "NormalAttack", EnumAttackResult.Block));
        return result;
      }

      var damage = RamdomDamage(attacker);

      result.SetSuccess(CombatInfo.New(attacker, target, "NormalAttack", EnumAttackResult.Hit, damage.DamagePoint));
      target.UnderAttack(damage);
      return result;
    }
    protected virtual bool ParryCheck(ITarget target)
    {
      var parryCheck = rnd.Next(1, 100);
      return target.ParryChance >= parryCheck;
    }
    protected virtual bool BlockCheck(ITarget target)
    {
      var blockCheck = rnd.Next(1, 100);
      return target.BlockChance >= blockCheck;
    }
    protected virtual bool DodgeCheck(ITarget target)
    {
      var blockCheck = rnd.Next(1, 100);
      return target.DodgeChance >= blockCheck;
    }
    protected virtual bool AttackCheck(ITarget attacker, ITarget target)
    {
      var hit = 100 * attacker.HitRate / (attacker.HitRate + target.DefenceRate) * 2 * attacker.Level / (attacker.Level + target.Level);
      hit = Math.Min(Math.Max(hit, 5), 95);
      return hit > rnd.Next(1, 100);
    }
    protected virtual Damage RamdomDamage(ITarget attacker)
    {
      int percent = rnd.Next(1, 101);
      var randomAttack = (attacker.MaxAttack - attacker.MinAttack) * percent / 100;
      var damageRange = attacker.MinAttack + randomAttack;
      var damageType = attacker.CurrentAttackSkill.DamageType ?? attacker.WeaponDamageType;
      return Damage.New(attacker, damageRange, damageType);
    }
  }
}
