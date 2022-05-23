using Entities;
using MoYu.Common.Affixes;
using MoYu.Common.ItemEffects;
using ReheeCmf.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints.Affixes
{
  public abstract class AffixBluePrintBase : EntityBase<long>, ISelect, IEquipPropertyBluePrint
  {
    public string SelectValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string SelectKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool SelectDisplay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string Name => throw new NotImplementedException();

    public EnumAffixesGroup Group { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ItemTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string StrengthRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DexterityRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string VitalityRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string EnergyRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string AttackRatingRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string AttackRatingPercentageRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string AttackRatingPerLevelRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamageMaxPerLevelRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamagePercentageRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamageMaxRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamageVsDemonRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamageVsUndeadRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamageColdRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamageFireRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamageLightningRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DamagePoisonRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string PoisonTimeSecondRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string DefencePercentageRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int ALevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool IsPrefix { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
}
