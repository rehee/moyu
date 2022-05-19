using Entities;
using MoYu.Entities.Items.Equipments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Characters
{
  public abstract class CharacterBase : MoYuBase
  {
    public string MaxHpSave { get; set; }
    public string CurrentHpSave { get; set; }

    [NotMapped]
    public BigInteger MaxHp
    {
      get
      {
        return BigInteger.Parse(MaxHpSave);
      }
      set
      {
        MaxHpSave = value.ToString();
      }
    }
    [NotMapped]
    public BigInteger CurrentHp
    {
      get
      {
        return BigInteger.Parse(CurrentHpSave);
      }
      set
      {
        CurrentHpSave = value.ToString();
      }
    }
    public int MaxResource { get; set; }
    public int CurrentResource { get; set; }
    public int Level { get; set; }
    
    [ForeignKey("WeaponEqip")]
    public string MainHandId { get; set; }
    public virtual WeaponEqip MainHand { get; set; }
    [ForeignKey("WeaponEqip")]
    public string OffHandId { get; set; }
    public virtual WeaponEqip OffHand { get; set; }
  }
}
