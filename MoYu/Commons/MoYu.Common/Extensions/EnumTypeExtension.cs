using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Extensions
{
  public static class MoYEnum
  {
    public static T?[] GetEnumTypeList<T>()
      where T : Enum
    {
      var property = typeof(T).GetAllFields().Where(b => b.FieldType == typeof(T)).ToList();
      return property.Select(b => b.GetValue(null))
        .Select(b =>
        {
          if (b == null)
          {
            return default(T);
          }
          if (b is T enums)
          {
            return enums;
          }
          return default(T);
        }).Where(b => b != null).Select(b => b).ToArray();
    }
  }
}
