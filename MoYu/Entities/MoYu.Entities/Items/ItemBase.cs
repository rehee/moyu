using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Items
{
  public abstract class MoYuItemBase : MoYuBase, IMoYuItem
  {
    public virtual void Use()
    {

    }
    public EnumItemType ItemType { get; set; }
    public abstract void PickUp();
  }
}
