﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Items
{
  public interface IItemService
  {
    IMoYuItem DropWeapon(int treasureLevel);
  }
}
