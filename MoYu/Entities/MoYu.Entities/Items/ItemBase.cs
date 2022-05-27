using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Items
{
  public abstract class MoYuItemBase : MoYuBase, IMoYuItem
  {
    public virtual void Use()
    {

    }
    public abstract void PickUp();

    public virtual int ItemLevel { get; set; }
    public EnumItemType ItemType { get; set; }
    [DataMember]
    public string PrefixName { get; set; }
    [DataMember]
    public string SuffixName { get; set; }

    public int? Strength { get; set; }
    public int? Dexterity { get; set; }
    public int? Vitality { get; set; }
    public int? Energy { get; set; }
    public int? AttackRating { get; set; }
    public int? AttackRatingPercentage { get; set; }
    public int? AttackRatingPerLevel { get; set; }
    public int? DamageMaxPerLevel { get; set; }
    public int? DamagePercentage { get; set; }
    public int? DamageMax { get; set; }
    public int? DamageVsDemon { get; set; }
    public int? DamageVsUndead { get; set; }
    public int? DamageCold { get; set; }
    public int? DamageFire { get; set; }
    public int? DamageLightning { get; set; }
    public int? DamagePoison { get; set; }
    public int? PoisonTimeSecond { get; set; }
    public int? Defence { get; set; }
    public int? DefencePercentage { get; set; }
    public int? Socket { get; set; }


  }
}
