using MoYu.Common.Affixes;
using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.ItemEffects
{
  public interface IEquipPropertyBluePrint
  {
    string Name { get; }
    EnumAffixesGroup Group { get; set; }
    IEnumerable<EnumItemType> ItemTypes { get; set; }
    EnumItemQuality Quality { get; set; }
    string ItemTypeValue { get; set; }
    int ALevel { get; set; }
    bool IsPrefix { get; set; }
    void SetAffixes(IEquipProperty item);
    string StrengthRange { get; set; }
    string DexterityRange { get; set; }
    string VitalityRange { get; set; }
    string EnergyRange { get; set; }
    string AttackRatingRange { get; set; }
    string AttackRatingPercentageRange { get; set; }
    string AttackRatingPerLevelRange { get; set; }
    string DamageMaxPerLevelRange { get; set; }
    string DamagePercentageRange { get; set; }
    string DamageMaxRange { get; set; }
    string AttackRateVsDemonRange { get; set; }
    string DamageVsDemonRange { get; set; }
    string AttackRateVsUndeadRange { get; set; }
    string DamageVsUndeadRange { get; set; }
    string DamageColdRange { get; set; }
    string DamageFireRange { get; set; }
    string DamageLightningRange { get; set; }
    string DamagePoisonRange { get; set; }
    string PoisonTimeSecondRange { get; set; }
    string DefenceRange { get; set; }
    string DefencePercentageRange { get; set; }
    string DefencePerLevel { get; set; }
    string DefencePercentagePerLevel { get; set; }
    string SocketRange { get; set; }
  }
}
