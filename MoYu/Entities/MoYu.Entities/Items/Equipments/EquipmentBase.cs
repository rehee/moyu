using MoYu.Common.Items;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Items.Equipments
{
  public abstract class EquipmentBase : MoYuItemBase
  {
    [DataMember]
    [JsonConverter(typeof(StringEnumConverter))]
    public EnumItemQuality Quality { get; set; }
    [DataMember]
    public bool IsEthereal { get; set; }
    public virtual void Equip()
    {

    }
    public virtual void UnEquip()
    {

    }
  }
}
