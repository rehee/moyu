using Authenticates;
using Cruds;
using FormInputs;
using Grids;
using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints.Weapons
{
  [Grid]
  public class WeaponBluePrintBase : BluePrintBase
  {
    public WeaponBluePrintBase()
    {
      this.ItemType = EnumItemType.Weapon;
    }
    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnmWeaponType WeaponType { get; set; }
    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnmWeaponHand WeaponHand { get; set; }
    public virtual List<WeaponBluePrint> Weapons { get; set; }


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
  }
}
