using Entities;
using MoYu.Common;
using MoYu.Common.Affixes;
using MoYu.Common.ItemEffects;
using MoYu.Common.Items;
using ReheeCmf.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints.Affixes
{
  public class AffixBluePrint : EntityBase<long>, ISelect, IEquipPropertyBluePrint
  {
    public string SelectValue { get => this.Name; set { } }
    public string SelectKey { get => $"{this.Id}"; set { } }
    public bool SelectDisplay { get => true; set { } }

    public string Name { get; set; }

    public EnumAffixesGroup Group { get; set; }
    public IEnumerable<EnumItemType> ItemTypes
    {
      get
      {
        if (String.IsNullOrEmpty(ItemTypeValue))
        {
          return Enumerable.Empty<EnumItemType>();
        }
        return ItemTypeValue.Split(",")
          .Select(b => (Enum.TryParse<EnumItemType>(b, out var enumValue), enumValue))
          .Where(b => b.Item1)
          .Select(b => b.enumValue);
      }
      set
      {
        ItemTypeValue = String.Join(",", value.Select(b => b.ToString()));
      }
    }
    public string ItemTypeValue { get; set; }
    public int ALevel { get; set; }
    public bool IsPrefix { get; set; }
    public void SetAffixes(IEquipProperty item)
    {
      var properties = this.GetMap().Properties.Select(p => (p, p.GetCustomAttributes<AffixeAttribute>())).Where(b => b.Item2 != null).ToList();
      foreach (var p in properties)
      {
        var value = (string)p.p.GetValue(this);
        if (String.IsNullOrEmpty(value))
        {
          continue;
        }
        var valueRange = value.Split(",").Select(b => b.GetValue<int>()).Where(b => b.Success).Select(b => b.Content).ToArray();
        var minValue = valueRange.FirstOrDefault();
        var maxValue = valueRange.Length > 1 ? valueRange[1] : minValue;
        var randonValue = 0;
        if (minValue == maxValue)
        {
          randonValue = minValue;

        }
        else
        {
          randonValue = MoYuRandom.GetNext(minValue, maxValue);
        }
        var currentValue = (int)p.Item2.Property.GetValue(item);
        p.Item2.Property.SetValue(item, currentValue + randonValue);
      }
    }
    [Affixe(nameof(IEquipProperty.Strength))]
    public string StrengthRange { get; set; }

    [Affixe(nameof(IEquipProperty.Dexterity))]
    public string DexterityRange { get; set; }

    [Affixe(nameof(IEquipProperty.Vitality))]
    public string VitalityRange { get; set; }

    [Affixe(nameof(IEquipProperty.Energy))]
    public string EnergyRange { get; set; }

    [Affixe(nameof(IEquipProperty.AttackRating))]
    public string AttackRatingRange { get; set; }

    [Affixe(nameof(IEquipProperty.AttackRatingPercentage))]
    public string AttackRatingPercentageRange { get; set; }

    [Affixe(nameof(IEquipProperty.AttackRatingPerLevel))]
    public string AttackRatingPerLevelRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamageMaxPerLevel))]
    public string DamageMaxPerLevelRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamagePercentage))]
    public string DamagePercentageRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamageMax))]
    public string DamageMaxRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamageVsDemon))]
    public string DamageVsDemonRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamageVsUndead))]
    public string DamageVsUndeadRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamageCold))]
    public string DamageColdRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamageFire))]
    public string DamageFireRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamageLightning))]
    public string DamageLightningRange { get; set; }

    [Affixe(nameof(IEquipProperty.DamagePoison))]
    public string DamagePoisonRange { get; set; }

    [Affixe(nameof(IEquipProperty.PoisonTimeSecond))]
    public string PoisonTimeSecondRange { get; set; }

    [Affixe(nameof(IEquipProperty.DefencePercentage))]
    public string DefencePercentageRange { get; set; }
  }
}
