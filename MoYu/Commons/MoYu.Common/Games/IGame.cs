using MoYu.Common.Combats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Games
{
  public interface IGame
  {
    string GameId { get; set; }
    string HostId { get; set; }
    
    ITarget Player { get; }
    ITarget Mob { get; }
  }
}
