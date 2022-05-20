using MoYu.Common;
using MoYu.Common.Combats;
using MoYu.Common.Games;
using MoYu.Entities.Characters;
using MoYu.Entities.Items.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoYu.Entities.Games
{
  public class Game : IGame
  {
    public string HostId { get; set; }
    public string GameId { get; set; }

    public ITarget Player { get; set; }
    public ITarget Mob { get; set; }

    public void Start()
    {
      Player = new CharacterBase()
      {
        Name = "Player",
        IsPlayer = true,
        CurrentHp = BigInteger.Parse("100"),
        MainHand = new WeaponEquip()
        {
          AttackSpeed = 3m,
          MinDamage = 1,
          MaxDamage = 8,

        }
      };
      Player.JoinGame(this);
      Mob = new CharacterBase()
      {
        Name = "mob",
        CurrentHp = BigInteger.Parse("15"),
      };
      Mob.JoinGame(this);
      Thread thread = new Thread(async () => await GameProcess());
      thread.IsBackground = true;
      thread.Start();
    }

    public async Task GameProcess()
    {
      await Task.Delay(1000 / General.FPS);
      Player.OnTick();
      Mob.OnTick();
      await GameProcess();
    }
    public Game()
    {
      HostId = Guid.NewGuid().ToString();
      GameId = Guid.NewGuid().ToString();

    }
  }
}
