using MoYu.Common.ItemEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Affixes
{
  public class AffixeAttribute : Attribute
  {

    public AffixeAttribute(string propertyName)
    {
      var ps = typeof(IEquipProperty).GetMap().Properties;
      Property = ps.FirstOrDefault(b => b.Name.Equals(propertyName));
    }
    public PropertyInfo Property { get; }
  }
}
