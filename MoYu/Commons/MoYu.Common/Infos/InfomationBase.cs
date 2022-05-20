using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Common.Infos
{
  public class InfomationBase : IInfo
  {
    public EnumInfoType InfoType { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Message { get; set; }
    public DateTime Time { get; set; }
  }
}
