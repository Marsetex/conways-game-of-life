using GameOfLife.Model.Cell.Base;
using System.Collections.Generic;

namespace GameOfLife.Controller
{
  public interface IGoLAlgorithm
  {
    IEnumerable<BaseCell> Next(IEnumerable<BaseCell> cells);
  }
}