using Cruds;
using FormInputs;
using Grids;
using MoYu.Common.Items;
using MoYu.Entities.BluePrints.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints
{
  [Grid]
  public class WeaponBluePrint : BluePrintBase
  {
    [FormInputs(InputType = EnumInputType.DropDown, RelatedEntity = typeof(WeaponBluePrintBase))]
    [ForeignKey(nameof(WeaponBluePrintBase))]
    public long BaseId { get; set; }
    public virtual WeaponBluePrintBase BaseWeapon { get; set; }
    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnumItemMaterial Material { get; set; }

    [FormInputs(InputType = EnumInputType.Number)]
    public int DamageMin { get; set; }
    [FormInputs(InputType = EnumInputType.Number)]
    public int DamageMax { get; set; }
    [FormInputs(InputType = EnumInputType.Number)]
    public decimal AttackSpeed { get; set; }

    //[FormInputs(InputType = EnumInputType.Number)]
    //public int Durability { get; set; }
    //[FormInputs(InputType = EnumInputType.Number)]
    //public int QualityLevel { get; set; }

  }
}
