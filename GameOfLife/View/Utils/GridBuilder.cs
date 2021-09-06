using GameOfLife.Model.Cell.Base;
using GameOfLife.View.Models;
using System.Collections.Generic;

namespace GameOfLife.View.Utils
{
  public static class GridBuilder
  {
    public static Grid Build(IEnumerable<BaseCell> cells, int gridEdgeLength)
    {
      var grid = new Grid(gridEdgeLength);
      InitGridWithDeadCells(grid);
      AddAliveCellsToGrid(grid, cells);
      return grid;
    }

    private static void InitGridWithDeadCells(Grid grid)
    {
      for (int i = 0; i < grid.EdgeLength; i++)
      {
        for (int k = 0; k < grid.EdgeLength; k++)
        {
          grid.Fields[i, k] = ".";
        }
      }
    }

    private static void AddAliveCellsToGrid(Grid grid, IEnumerable<BaseCell> _aliveCells)
    {
      foreach (var cell in _aliveCells)
      {
        grid.Fields[cell.x, cell.y] = "■";
      }
    }
  }
}
