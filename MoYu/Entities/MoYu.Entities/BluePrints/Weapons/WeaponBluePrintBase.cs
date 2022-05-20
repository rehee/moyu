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
  public class WeaponBluePrintBase: BluePrintBase
  {
    public WeaponBluePrintBase()
    {
      this.ItemType = EnumItemType.Weapon;
    }
    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnmWeaponType WeaponType { get; set; }
    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnmWeaponHand WeaponHand { get; set; }
  }
}
