using Entities;
using Inject;
using MoYu.Common;
using MoYu.Common.Combats;
using MoYu.Common.Games;
using MoYu.Common.Skills;
using MoYu.Entities.Items.Equipments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Characters
{
  public class CharacterBase : MoYuBase, ITarget, IDefaultSkill
  {
    protected virtual IAttackService attackService { get; set; }
    public CharacterBase()
    {
      attackService = PropertyInject.GetService<IAttackService>();
    }
    public bool IsPlayer { get; set; }
    #region basic property
    public string MaxHpSave { get; set; }
    protected virtual IGame game { get; set; }
    public virtual IGame Game => game;
    public virtual void JoinGame(IGame game)
    {
      this.game = game;
    }
    public virtual BigInteger MinAttack
    {
      get
      {
        var weaponMin = MainHand != null ? new BigInteger(MainHand.DamageMin) : new BigInteger(1);

        return weaponMin;
      }
    }
    public virtual BigInteger MaxAttack
    {
      get
      {
        var weaponMax = MainHand != null ? new BigInteger(MainHand.DamageMax) : new BigInteger(1);

        return weaponMax;
      }
    }
    public EnumDamageType WeaponDamageType
    {
      get
      {
        return MainHand != null ? MainHand.DamageType : EnumDamageType.Physic;
      }
    }
    public int DodgeChance
    {
      get
      {
        return 15;
      }
    }
    public int ParryChance
    {
      get
      {
        return 15;
      }
    }
    public int HitRate
    {
      get
      {
        return 100;
      }
    }
    public int DefenceRate
    {
      get
      {
        return 100;
      }
    }
    public int BlockChance
    {
      get
      {
        return 75;
      }
    }

    [NotMapped]
    public BigInteger MaxHp
    {
      get
      {
        var baseMaxHp = BigInteger.Parse(MaxHpSave);
        return baseMaxHp;
      }
      set
      {
        MaxHpSave = value.ToString();
      }
    }
    [NotMapped]
    public BigInteger CurrentHp { get; set; }

    public int MaxResource { get; set; }
    [NotMapped]
    public int CurrentResource { get; set; }
    public int Level { get; set; } = 1;
    #endregion
    #region equip slot
    [ForeignKey(nameof(WeaponEquip))]
    public string MainHandId { get; set; }
    public virtual WeaponEquip MainHand { get; set; }
    [ForeignKey(nameof(WeaponEquip))]
    public string OffHandId { get; set; }
    public virtual WeaponEquip OffHand { get; set; }
    [ForeignKey(nameof(BeltEquip))]
    public string BeltId { get; set; }
    public virtual BeltEquip Belt { get; set; }

    [ForeignKey(nameof(BodyEquip))]
    public string BodyId { get; set; }
    public virtual BodyEquip Body { get; set; }

    [ForeignKey(nameof(FeetEquip))]
    public string FeetId { get; set; }
    public virtual FeetEquip Feet { get; set; }

    [ForeignKey(nameof(HandEquip))]
    public string HandId { get; set; }
    public virtual HandEquip Hand { get; set; }

    [ForeignKey(nameof(HeadEquip))]
    public string HeadId { get; set; }
    public virtual HeadEquip Head { get; set; }

    [ForeignKey(nameof(LegEquip))]
    public string LegEquipdId { get; set; }
    public virtual LegEquip Leg { get; set; }

    [ForeignKey(nameof(NeckEquip))]
    public string NeckId { get; set; }
    public virtual NeckEquip Neck { get; set; }

    [ForeignKey(nameof(RingEquip))]
    public string RingMainHandId { get; set; }
    public virtual RingEquip RingMainHand { get; set; }

    [ForeignKey(nameof(RingEquip))]
    public string RingOffHandId { get; set; }
    public virtual RingEquip RingOffHand { get; set; }
    #endregion


    [NotMapped]
    public virtual decimal AttackSpeed
    {
      get
      {
        var baseAttack = MainHand != null ? MainHand.AttackSpeed : this.AttackSpeedUnArmed;
        return baseAttack;
      }
    }
    [NotMapped]
    public virtual decimal AttackSpeedUnArmed { get; } = 1.5m;

    [NotMapped]
    public virtual int? AttackFrames
    {
      get
      {
        if (AttackSpeed > 0)
        {
          var attackFrame = General.FPS / AttackSpeed;
          return Decimal.ToInt32(attackFrame);
        }
        return null;
      }
    }

    [NotMapped]
    public virtual int AttackProgress { get; set; }

    public virtual ITarget Target { get; private set; }
    public virtual void SetTarget(ITarget target)
    {
      this.Target = target;
    }

    public virtual AttackSkill CurrentAttackSkill
    {
      get
      {
        return SelectedAttackSkill ?? DefaultSkill;
      }
    }
    public virtual AttackSkill SelectedAttackSkill { get; set; }

    public virtual AttackSkill DefaultSkill => new AttackSkill()
    {
      Name = GeneralSkills.DefaultAttackSkilName
    };

    public virtual void OnTick()
    {
      if (IsPlayer && Target == null && game.Mob != null && game.Mob.CurrentHp > 0)
      {
        SetTarget(game.Mob);
      }
      
      Attack();
    }

    public virtual void Attack()
    {
      if (!AttackFrames.HasValue || Target == null || Target.CurrentHp <= 0 || CurrentHp <= 0)
      {
        AttackProgress = 0;
        return;
      }
      AttackProgress++;
      if (AttackProgress >= AttackFrames.Value)
      {
        AttackProgress = 0;
        var attackResult = attackService.Attack(this, Target);
        if (attackResult.Success)
        {
          Console.WriteLine($"{attackResult.Content.Time.StringValue()} {attackResult.Content.Message}");
        }
      }
    }
    public virtual void UnderAttack(Damage damage)
    {
      if (damage.DamagePoint <= 0)
      {
        return;
      }
      if (Target == null)
      {
        SetTarget(damage.Attacker);
      }

      this.CurrentHp = this.CurrentHp - damage.DamagePoint;

    }


  }
}
