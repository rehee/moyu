using MoYu.Common.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Combats
{
  public interface IDefaultSkill
  {
    AttackSkill DefaultSkill { get; }
  }
}
