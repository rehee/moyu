using Entities;
using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints
{
  public class BluePrintBase : EntityBase<long>, IBluePrint
  {
    public string Name { get; set; }
    public uint Durability { get; set; }
    public uint QualityLevel { get; set; }


  }
}
