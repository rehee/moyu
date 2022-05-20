using Cruds;
using FormInputs;
using Grids;
using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints
{
  [Grid]
  public class WeaponBluePrint : BluePrintBase
  {
    public EnmWeaponType WeaponType { get; set; }
    public EnmWeaponHand WeaponHand { get; set; }
    [FormInputs(InputType = EnumInputType.Number)]
    public int DamageMin { get; set; }
    public int DamageMax { get; set; }
    public decimal AttackSpeed { get; set; }

  }
}
