using GameOfLife.Model.Cell.Base;
using System.Collections.Generic;

namespace GameOfLife.Controller
{
  public class GoLAlgorithm : IGoLAlgorithm
  {
    #region IGoLAlgorithm

    public IEnumerable<BaseCell> Next(IEnumerable<BaseCell> cells)
    {
      var currentGenAliveCells = new HashSet<BaseCell>(cells);
      var cellsToCheck = GetCellsToCheckThisGeneration(currentGenAliveCells);

      var nextGenAliveCells = new List<BaseCell>();
      foreach (var cell in cellsToCheck)
      {
        var newCell = cell.ApplyRules(currentGenAliveCells);
        if(newCell != null)
        {
          nextGenAliveCells.Add(newCell);
        }
      }
     
      return nextGenAliveCells;
    }

    #endregion

    private HashSet<BaseCell> GetCellsToCheckThisGeneration(HashSet<BaseCell> currentGenAliveCells)
    {
      var cellsToCheck = new HashSet<BaseCell>(currentGenAliveCells);
      foreach (var aliveCell in currentGenAliveCells)
      {
        cellsToCheck.UnionWith(aliveCell.GetDeadNeighbours(currentGenAliveCells));
      }

      return cellsToCheck;
    }
  }
}
