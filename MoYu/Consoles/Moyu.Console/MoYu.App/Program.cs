using MoYu.Common;
using System.Numerics;

namespace MoYu.App
{
  internal class Program
  {
    static void Main(string[] args)
    {

      for (var i = 0; i < 100; i++)
      {
        Console.WriteLine(MoYuRandom.GetNext(0, 2));
      }
    }
  }
}