using MoYu.Common.Combats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Items.Equipments
{
  public class WeaponEquip : EquipmentBase
  {
    public EnmWeaponHand WeaponHand { get; set; }
    public virtual decimal AttackSpeed { get; set; }
    public virtual uint MinDamage { get; set; }
    public virtual uint MaxDamage { get; set; }
    public virtual EnumDamageType DamageType { get; set; }
  }
}
