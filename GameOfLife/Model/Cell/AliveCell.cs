using GameOfLife.Model.Cell.Base;
using System.Collections.Generic;

namespace GameOfLife.Model.Cell
{
  public class AliveCell : BaseCell
  {
    public AliveCell(int x, int y) : base(x, y) { }

    public override BaseCell ApplyRules(HashSet<BaseCell> currentGenAliveCells)
    {
      var aliveNeighbours = GetAliveNeighbours(currentGenAliveCells);
      var aliveNeighboursCount = aliveNeighbours.Count;

      if (aliveNeighboursCount < 2 || aliveNeighboursCount > 3)
      {
        return null;
      }

      return new AliveCell(x, y);
    }
  }
}
