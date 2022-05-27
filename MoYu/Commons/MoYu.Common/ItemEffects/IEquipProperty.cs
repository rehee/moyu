using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.ItemEffects
{
  public interface IEquipProperty
  {
    string? PrefixName { get; set; }
    string? SuffixName { get; set; }
    int? Strength { get; set; }
    int? Dexterity { get; set; }
    int? Vitality { get; set; }
    int? Energy { get; set; }
    int? AttackRating { get; set; }
    int? AttackRatingPercentage { get; set; }
    int? AttackRatingPerLevel { get; set; }
    int? DamageMaxPerLevel { get; set; }
    int? DamagePercentage { get; set; }
    int? DamageMax { get; set; }
    int? DamageVsDemon { get; set; }
    int? DamageVsUndead { get; set; }
    int? DamageCold { get; set; }
    int? DamageFire { get; set; }
    int? DamageLightning { get; set; }
    int? DamagePoison { get; set; }
    int? PoisonTimeSecond { get; set; }
    int? Defence { get; set; }
    int? DefencePercentage { get; set; }
    int? Socket { get; set; }
  }
}
