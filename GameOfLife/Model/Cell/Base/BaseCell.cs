using System;
using System.Linq;
using System.Collections.Generic;

namespace GameOfLife.Model.Cell.Base
{
  public abstract class BaseCell
  {
    #region Fields

    public int x;
    public int y;

    #endregion

    protected BaseCell(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    #region Object overrides

    public override bool Equals(object obj)
    {
      return obj is BaseCell cell &&
             x == cell.x &&
             y == cell.y;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(x, y);
    }

    #endregion

    #region Abstract methods

    public abstract BaseCell ApplyRules(HashSet<BaseCell> currentGenAliveCells);

    #endregion

    public ICollection<BaseCell> GetDeadNeighbours(HashSet<BaseCell> cells)
    {
      var neighbours = new List<BaseCell>
      {
        new DeadCell(x - 1, y - 1),
        new DeadCell(x - 1, y),
        new DeadCell(x - 1, y + 1),
        new DeadCell(x, y - 1),
        new DeadCell(x, y + 1),
        new DeadCell(x + 1, y - 1),
        new DeadCell(x + 1, y),
        new DeadCell(x + 1, y + 1)
      };

      return neighbours.Where(c => !cells.Contains(c)).ToList();
    }

    public ICollection<BaseCell> GetAliveNeighbours(HashSet<BaseCell> cells)
    {
      var neighbours = new List<BaseCell>
      {
        new AliveCell(x - 1, y - 1),
        new AliveCell(x - 1, y),
        new AliveCell(x - 1, y + 1),
        new AliveCell(x, y - 1),
        new AliveCell(x, y + 1),
        new AliveCell(x + 1, y - 1),
        new AliveCell(x + 1, y),
        new AliveCell(x + 1, y + 1)
      };

      return neighbours.Where(c => cells.Contains(c)).ToList();
    }
  }
}