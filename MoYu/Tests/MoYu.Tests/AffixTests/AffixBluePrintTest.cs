using MoYu.Common.ItemEffects;
using MoYu.Entities.BluePrints.Affixes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Tests.AffixTests
{
  public class AffixBluePrintTest
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
      var bluePrint = new AffixBluePrint();
      bluePrint.StrengthRange = "1";
      var equip = new TestEquipProperty();
      
      equip.Dexterity = 1;
      bluePrint.DexterityRange = "2,2";
      bluePrint.SetAffixes(equip);
      Assert.AreEqual(1, equip.Strength);
      Assert.AreEqual(3, equip.Dexterity);
    }
  }

  public class TestEquipProperty : IEquipProperty 
  {
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Vitality { get; set; }
    public int Energy { get; set; }
    public int AttackRating { get; set; }
    public int AttackRatingPercentage { get; set; }
    public int AttackRatingPerLevel { get; set; }
    public int DamageMaxPerLevel { get; set; }
    public int DamagePercentage { get; set; }
    public int DamageMax { get; set; }
    public int DamageVsDemon { get; set; }
    public int DamageVsUndead { get; set; }
    public int DamageCold { get; set; }
    public int DamageFire { get; set; }
    public int DamageLightning { get; set; }
    public int DamagePoison { get; set; }
    public int PoisonTimeSecond { get; set; }
    public int Defence { get; set; }
    public int DefencePercentage { get; set; }
  }

}
