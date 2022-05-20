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
    public BluePrintBase()
    {

    }
    public string Name { get; set; }
    public int Durability { get; set; }
    public int QualityLevel { get; set; }


  }
}
