using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Infos
{
  public interface IInfo
  {
    EnumInfoType InfoType { get; set; }
    string From { get; set; }
    string To { get; set; }
    string Message { get; set; }
    DateTime Time { get; set; }
  }
}
