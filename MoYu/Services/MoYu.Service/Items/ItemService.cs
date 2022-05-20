using MoYu.Common;
using MoYu.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Service.Items
{
  public class ItemService : IItemService
  {
    protected Random rdm;
    protected EnumItemType[] itemTypes;
    public ItemService()
    {
      rdm = new Random();
      var property = typeof(EnumItemType).GetAllFields().Where(b => b.FieldType == typeof(EnumItemType)).ToList();
      itemTypes = property.Select(b => b.GetValue(null)).Select(b =>
      {
        if (b is EnumItemType enums)
        {
          return (EnumItemType?)enums;
        }
        return null;
      }).Where(b => b.HasValue).Select(b => b.Value).ToArray();
    }
    public RequestResponse<IMoYuItem[]> DropItem(IDroppable dropper)
    {
      var result = new RequestResponse<IMoYuItem[]>();



      return result;
    }

    protected virtual void DropFromDropper(IDroppable dropper, List<IMoYuItem> items)
    {
      if (items.Count >= General.MaxDropPerDropper)
      {
        return;
      }


    }

    protected virtual EnumItemType GetRamdonType()
    {
      var index = rdm.Next(0, itemTypes.Length);
      return itemTypes[index];
    }
  }
}
