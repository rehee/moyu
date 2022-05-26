using MoYu.Common.ItemEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common
{
  public static class General
  {
    public const int FPS = 24;
    public const int MaxDropPerDropper = 6;
    public const int BrokenRange = 10;
    public const int SuperiorRange = 90;
    public const decimal BrokenModifyBase = 0.10m;
    public const decimal BrokenModifyRange = 0.05m;
    public const decimal SuperiorModifyBase = 0.10m;
    public const decimal SuperiorModifyRange = 0.05m;
    public const int EtherealRange = 5;
    public const decimal EtherealModify = 0.5m;
    public const int PrefixMagic = 1;
    public const int PrefixRare = 3;
    public const int SuffixMagic = 1;
    public const int SuffixRare = 3;

    public static IEquipPropertyBluePrint[] Affixes { get; set; }
  }
}
