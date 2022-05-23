using Cruds;
using FormInputs;
using Grids;
using MoYu.Common.Items;
using MoYu.Entities.Items;
using MoYu.Entities.Items.Equipments;
using MoYu.Entities.Items.Equipments.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints.Equips.Weapons
{
  [Grid]
  public class WeaponBluePrint : BluePrintBase
  {
    [FormInputs(InputType = EnumInputType.DropDown, RelatedEntity = typeof(WeaponBaseBluePrint))]
    [ForeignKey(nameof(WeaponBaseBluePrint))]
    public long BaseId { get; set; }
    public virtual WeaponBaseBluePrint BaseWeapon { get; set; }

    [NotMapped]
    public string BaseName { get; set; }

    [FormInputs(InputType = EnumInputType.DropDown)]
    public EnumItemMaterial Material { get; set; }

    [FormInputs(InputType = EnumInputType.Number)]
    public int DamageMin { get; set; }
    [FormInputs(InputType = EnumInputType.Number)]
    public int DamageMax { get; set; }

    [FormInputs(InputType = EnumInputType.Number)]
    public int Durability { get; set; }


    public override IMoYuItem GenerateItem()
    {
      return WeaponEquip.Create(this);
    }
  }
}
