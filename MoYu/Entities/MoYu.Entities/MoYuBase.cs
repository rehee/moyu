using Authenticates;
using Cruds;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities
{
  public abstract class MoYuBase : EntityBase<string>
  {
    [DataMember]
    public string Name { get; set; }
    public override void BeforeCreate(IContext context, TokenDTO user)
    {
      base.BeforeCreate(context, user);
      Id = Guid.NewGuid().ToString();
    }
  }
}
