using MoYu.Common.ItemEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Items
{
  public interface IMoYuItem : IName, IEquipProperty
  {
    int ItemLevel { get; set; }
  }
}
