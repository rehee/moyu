using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePoints
{
  public class BluePointBase : EntityBase<long>
  {
    public string TemplateName { get; set; }
    public string Name { get; set; }

    
  }
}
