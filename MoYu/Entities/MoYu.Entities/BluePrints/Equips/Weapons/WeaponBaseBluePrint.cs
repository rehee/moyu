using Authenticates;
using Cruds;
using FormInputs;
using Grids;
using MoYu.Common.Items;
using MoYu.Entities.BluePrints.Equips;
using MoYu.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints.Equips.Weapons
{
  [Grid]
  public class WeaponBaseBluePrint : EquipBluePrint
  {
    public WeaponBaseBluePrint()
    {
      this.ItemType = EnumItemType.Weapon;
    }
    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnumWeaponType WeaponType { get; set; }
    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnumWeaponHand WeaponHand { get; set; }
    public virtual List<WeaponBluePrint> Weapons { get; set; }

    [FormInputs(InputType = EnumInputType.Number)]
    public decimal AttackSpeed { get; set; }

    public override void BeforeCreate(IContext context, TokenDTO user)
    {
      base.BeforeCreate(context, user);
      var normalWeapon = new WeaponBluePrint()
      {
        BaseWeapon = this,
        BaseId = this.Id,
        Material = EnumItemMaterial.Normal
      };
      var extendlWeapon = new WeaponBluePrint()
      {
        BaseWeapon = this,
        BaseId = this.Id,
        Material = EnumItemMaterial.Extend
      };
      var eliteWeapon = new WeaponBluePrint()
      {
        BaseWeapon = this,
        BaseId = this.Id,
        Material = EnumItemMaterial.Elite
      };

      currentContext.Create(normalWeapon, null, false);
      currentContext.Create(extendlWeapon, null, false);
      currentContext.Create(eliteWeapon, null, false);
    }

    public override IMoYuItem GenerateItem()
    {
      throw new NotImplementedException();
    }
  }
}
