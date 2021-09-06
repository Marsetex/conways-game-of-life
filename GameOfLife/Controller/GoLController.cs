using System;
using System.Collections.Generic;
using GameOfLife.Model;
using GameOfLife.Model.Cell;
using GameOfLife.Model.Cell.Base;
using GameOfLife.View;
using GameOfLife.View.Contracts;

namespace GameOfLife.Controller
{
  public class GoLController
  {
    private readonly GameState _state;
    private readonly IUserInterface _ui;
    private readonly GoLAlgorithm _alogrithm; 

    public GoLController()
    {
      _state = new GameState();
      _ui = new TerminalUi(_state);
      _alogrithm = new GoLAlgorithm();
    }

    public void Start()
    {
      InitGameState();
      _ui.Display();

      while (Console.ReadKey().Key != ConsoleKey.Escape)
      {
        _state.cells = _alogrithm.Next(_state.cells);
        _ui.Display();
      }
    }

    private void InitGameState()
    {
      _state.cells = new List<BaseCell>
      {
        // Blinker
        //new AliveCell(3, 2),
        //new AliveCell(3, 3),
        //new AliveCell(3, 4),

        // Gleiter
        //new AliveCell(1, 3),
        //new AliveCell(2, 4),
        //new AliveCell(3, 2),
        //new AliveCell(3, 3),
        //new AliveCell(3, 4),

        // Sterbende Punkte
        //new AliveCell(2, 2),
        //new AliveCell(3, 3),

        // Statischer wuerfel
        //new AliveCell(2, 2),
        //new AliveCell(2, 3),
        //new AliveCell(3, 2),
        //new AliveCell(3, 3),

        // Oktagon
        new AliveCell(3, 2),
        new AliveCell(2, 3),
        new AliveCell(3, 4),
        new AliveCell(3, 5),
        new AliveCell(2, 6),
        new AliveCell(3, 7),

        new AliveCell(4, 3),
        new AliveCell(5, 3),
        new AliveCell(4, 6),
        new AliveCell(5, 6),

        new AliveCell(6, 2),
        new AliveCell(7, 3),
        new AliveCell(6, 4),
        new AliveCell(6, 5),
        new AliveCell(7, 6),
        new AliveCell(6, 7),
      };
    }
  }
}