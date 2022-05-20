using MoYu.Common.Combats;
using MoYu.Common.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Combats
{
  public interface IAttackService
  {
    RequestResponse<IInfo> Attack(ITarget attacker, ITarget target);
  }
}
