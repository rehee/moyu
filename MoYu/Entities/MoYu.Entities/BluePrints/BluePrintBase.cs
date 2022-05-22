using Entities;
using FormInputs;
using MoYu.Common.Items;
using ReheeCmf.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.BluePrints
{
  public class BluePrintBase : EntityBase<long>, ISelect
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
  }
}
