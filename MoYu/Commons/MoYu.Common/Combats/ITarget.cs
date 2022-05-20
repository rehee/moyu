using MoYu.Common.Games;
using MoYu.Common.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Combats
{
  public interface ITarget : IName, IStringId
  {
    BigInteger MaxHp { get; }
    BigInteger CurrentHp { get; }

    BigInteger MinAttack { get; }
    BigInteger MaxAttack { get; }
    EnumDamageType WeaponDamageType { get; }
    IGame Game { get; }
    void JoinGame(IGame game);
    int Level { get; }
    int HitRate { get; }
    int DefenceRate { get; }
    int BlockChance { get; }
    int DodgeChance { get; }
    int ParryChance { get; }
    AttackSkill CurrentAttackSkill { get; }
    ITarget Target { get; }
    void SetTarget(ITarget targer);
    void Attack();
    void UnderAttack(Damage damage);

    void OnTick();
  }
}
