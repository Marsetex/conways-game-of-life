using System.Collections.Generic;
using GameOfLife.Model.Cell.Base;

namespace GameOfLife.Model.Cell
{
  public class DeadCell : BaseCell
  {
    public DeadCell(int x, int y) : base(x, y) { }

    public override BaseCell ApplyRules(HashSet<BaseCell> currentGenAliveCells)
    {
      var aliveNeighbours = GetAliveNeighbours(currentGenAliveCells);
      var aliveNeighboursCount = aliveNeighbours.Count;

      if (aliveNeighboursCount != 3)
      {
        return null;
      }

      return new AliveCell(x, y);
    }
  }
}
