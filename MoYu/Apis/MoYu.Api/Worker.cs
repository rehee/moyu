using MoYu.Common.Items;
using MoYu.Entities.Games;
using System.Collections.Concurrent;

namespace MoYu.WorkerService
{
  public class Worker : BackgroundService
  {
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
      _logger = logger;
    }
    public ConcurrentDictionary<string, Game> Games = new ConcurrentDictionary<string, Game>();
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
     
      //var gams = new Game[] { new Game() };
      //foreach (var game in gams)
      //{
      //  Games.TryAdd(game.GameId, game);
      //  game.Start();
      //}

      //while (!stoppingToken.IsCancellationRequested)
      //{
      //  _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      //  await Task.Delay(1000, stoppingToken);
      //}
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    }
  }
}