using MoYu.Common.ItemEffects;
using MoYu.Entities.BluePrints.Affixes;
using MoYu.Entities.Items.Equipments.Weapons;
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
      var equip = new WeaponEquip();

      equip.Dexterity = 1;
      bluePrint.DexterityRange = "2,2";
      bluePrint.SetAffixes(equip);
      Assert.AreEqual(1, equip.Strength);
      Assert.AreEqual(3, equip.Dexterity);
    }
  }
}
