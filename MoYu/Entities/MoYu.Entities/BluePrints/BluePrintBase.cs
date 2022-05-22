using Entities;
using FormInputs;
using MoYu.Common.Items;
using MoYu.Entities.Items;
using ReheeCmf.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints
{
  public abstract class BluePrintBase : EntityBase<long>, ISelect
  {
    [FormInputs(InputType = EnumInputType.Text, DisplayOrder = -1)]
    public string Name { get; set; }
    public EnumItemType ItemType { get; set; }
    public virtual string SelectValue
    {
      get
      {
        return Name;
      }
      set
      {

      }
    }
    public virtual string SelectKey
    {
      get
      {
        return Id.StringValue();
      }
      set
      {

      }
    }
    public virtual bool SelectDisplay
    {
      get
      {
        return true;
      }
      set
      {

      }
    }

    [FormInputs(InputType = EnumInputType.Number)]
    public int QualityLevel { get; set; }
    [FormInputs(InputType = EnumInputType.Number)]
    public int TreasureClass { get; set; }

    public abstract IMoYuItem GenerateItem();
  }
}
