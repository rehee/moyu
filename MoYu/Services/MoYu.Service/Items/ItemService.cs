using Cruds;
using MoYu.Common;
using MoYu.Common.Extensions;
using MoYu.Common.Items;
using MoYu.Entities.BluePrints.Equips.Weapons;
using MoYu.Entities.Items.Equipments;
using MoYu.Entities.Items.Equipments.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Service.Items
{
  public class ItemService : IItemService
  {
    protected EnumItemType[] itemTypes;
    protected EnumWeaponType[] weaponTypes;
    protected WeaponBaseBluePrint[] weaponBases;
    protected WeaponBluePrint[] weapons;
    protected EnumItemQuality[] qualities;
    private readonly IContext context;

    public ItemService(IContextFactory factory)
    {
      itemTypes = MoYEnum.GetEnumTypeList<EnumItemType>();
      weaponTypes = MoYEnum.GetEnumTypeList<EnumWeaponType>();
      qualities = MoYEnum.GetEnumTypeList<EnumItemQuality>();
      this.context = factory.CreateContext();
      weaponBases = context.Read<WeaponBaseBluePrint>().Content.ToArray();
      weapons = context.Read<WeaponBluePrint>().Content.ToArray();

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

      var dropType = GetRamdonType();

    }

    protected virtual EnumItemType GetRamdonType()
    {
      return itemTypes.GetRamdon();
    }



    public IMoYuItem DropWeapon(int treasureLevel)
    {
      var randomWeaponType = weaponBases
        .Where(b => b.Weapons.Any(w => w.QualityLevel <= treasureLevel))
        .GroupBy(b => b.WeaponType)
        .Select(b => b.Key)
        .ToArray()
        .GetRamdon();
      var w = weapons
        .Where(b => b.BaseWeapon.WeaponType == randomWeaponType && b.QualityLevel <= treasureLevel)
        .ToArray()
        .GetRamdon();
      var wbItem = w.GenerateItem();
      wbItem.ItemLevel = treasureLevel;
      if (wbItem is WeaponEquip weapon)
      {
        weapon.Quality = MoYuRandom.GetQuality(1000, 1, 1, 1, 5);
        weapon.SetEthereal(MoYuRandom.GetEthereal());
      }

      return wbItem;
    }

    public void SetAffixes(IMoYuItem item)
    {

      if (item is EquipmentBase equip != true)
      {
        return;
      }
      if (equip.Quality == EnumItemQuality.Normal)
      {
        return;
      }
      var quality = equip.Quality;
      int prefix = 0;
      int suffix = 0;
      if (equip.Quality == EnumItemQuality.Magic)
      {
        prefix = MoYuRandom.GetNext(0, General.PrefixMagic + 1);
        suffix = MoYuRandom.GetNext(0, General.SuffixMagic + 1);

      }
      else
      {
        prefix = MoYuRandom.GetNext(0, General.PrefixRare + 1);
        suffix = MoYuRandom.GetNext(0, General.SuffixRare + 1);
      }
      if (prefix == 0 && suffix == 0)
      {
        var isPrefix = MoYuRandom.GetNext(0, 2);
        if (isPrefix == 1)
        {
          prefix = 1;
        }
        else
        {
          suffix = 1;
        }
      }
     
      var prefixs = General.Affixes
        .Where(b => b.IsPrefix && b.Quality == quality && b.ALevel <= equip.ItemLevel && b.ItemTypes.Contains(equip.ItemType))
        .ToArray().GroupBy(b => b.Group);
      var preGroup = prefixs.ToArray().GetRandomIn(prefix);
      foreach (var p in preGroup)
      {
        var uniq = p.GroupBy(b => b.Name).Select(b => b.OrderByDescending(b => b.ALevel).First()).ToArray().GetRamdon();
        uniq.SetAffixes(item);
      }
    }
  }
}
