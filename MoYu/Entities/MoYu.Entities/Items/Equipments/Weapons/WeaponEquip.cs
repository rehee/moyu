using MoYu.Common.Combats;
using MoYu.Common.Items;
using MoYu.Entities.BluePrints.Equips.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Items.Equipments.Weapons
{
  public class WeaponEquip : EquipmentBase
  {
    public static WeaponEquip Create(WeaponBluePrint bluePrint)
    {

      return new WeaponEquip()
      {
        Id = Guid.NewGuid().ToString(),
        Name = bluePrint.Name,
        ItemType = bluePrint.BaseWeapon.ItemType,
        WeaponType = bluePrint.BaseWeapon.WeaponType,
        WeaponHand = bluePrint.BaseWeapon.WeaponHand,
        WeaponDamageMin = bluePrint.DamageMin,
        WeaponDamageMax = bluePrint.DamageMax,
        AttackSpeed = bluePrint.BaseWeapon.AttackSpeed
      };
    }

    public override void PickUp()
    {
      throw new NotImplementedException();
    }

    public EnumWeaponType WeaponType { get; set; }
    public EnumWeaponHand WeaponHand { get; set; }
    public virtual decimal AttackSpeed { get; set; }
    public virtual int WeaponDamageMin { get; set; }
    public virtual int WeaponDamageMax { get; set; }
    public virtual EnumDamageType DamageType { get; set; }
  }
}
