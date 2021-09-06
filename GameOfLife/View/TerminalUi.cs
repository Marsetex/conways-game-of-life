using System;
using System.Collections.Generic;
using GameOfLife.Model;
using GameOfLife.Model.Cell.Base;
using GameOfLife.View.Contracts;
using GameOfLife.View.Models;
using GameOfLife.View.Utils;

namespace GameOfLife.View
{
  public class TerminalUi : IUserInterface
  {
    private readonly GameState _state;

    public TerminalUi(GameState state)
    {
      _state = state;
    }

    public void Display()
    {
      Console.Clear();
      OutputGrid(GridBuilder.Build(_state.cells, 25));
    }

    private void OutputGrid(Grid grid)
    {
      for (int i = 0; i < grid.EdgeLength; i++)
      {
        for (int k = 0; k < grid.EdgeLength; k++)
        {
          Console.Write(grid.Fields[i, k] + " ");
        }
        Console.Write("\n");
      }
    }
  }
}
