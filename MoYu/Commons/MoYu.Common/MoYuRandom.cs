using MoYu.Common.Extensions;
using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common
{
  public static class MoYuRandom
  {
    public static EnumItemQuality[] Qualities => MoYEnum.GetEnumTypeList<EnumItemQuality>();
    public static Random GetRamdon(int? seed = null)
    {
      if (seed == null)
      {
        byte[] buffer = Guid.NewGuid().ToByteArray();
        seed = BitConverter.ToInt32(buffer);
      }
      return new Random(seed.Value);
    }
    public static bool GetEthereal()
    {
      return General.EtherealRange > MoYuRandom.GetNext(0, 100); ;
    }
    public static EnumItemQuality GetQuality(
      int magicFind, decimal uniqueDrop, decimal setDrop, decimal rairDrop, decimal magicDrop)
    {
      var uniqueFind = 0;
      var setFind = 0;
      var rairFind = 0;
      if (magicFind <= 10)
      {
        uniqueFind = magicFind;
        setFind = magicFind;
        rairFind = magicFind;
      }
      else
      {
        uniqueFind = (magicFind * 250 / (magicFind + 250));
        setFind = (magicFind * 500 / (magicFind + 500));
        rairFind = (magicFind * 600 / (rairFind + 600));
      }
      var random = GetNext(0, 1000000);
      var ud = uniqueDrop * (100 + uniqueFind) * 100;
      if (ud > random)
      {
        return EnumItemQuality.Unique;
      }
      var sd = setDrop * (100 + setFind) * 100;
      if (sd > random)
      {
        return EnumItemQuality.Set;
      }
      var rd = rairDrop * (100 + rairFind) * 100;
      if (rd > random)
      {
        return EnumItemQuality.Rare;
      }
      var md = magicDrop * (100 + magicFind) * 100;
      if (md > random)
      {
        return EnumItemQuality.Magic;
      }

      return EnumItemQuality.Normal;
    }
    public static int GetNext(int min, int max)
    {
      return GetRamdon().Next(min, max);
    }
    public static T GetRamdon<T>(this T[] input)
    {
      var index2 = GetRamdon().Next(0, input.Length);
      return input[index2];
    }

    public static List<T> GetRandomIn<T>(this T[] input, int number, List<T> result = null)
    {
      if (result == null)
      {
        result = new List<T>();
      }
      if (input.Length <= 0 || number <= 0)
      {
        return result;
      }
      var index2 = GetRamdon().Next(0, input.Length);
      result.Add(input[index2]);
      GetRandomIn(input.Where((b, i) => i != index2).ToArray(), number - 1, result);
      return result;
    }
  }
}
