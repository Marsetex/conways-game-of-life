namespace GameOfLife.View.Models
{
  public class Grid
  {
    public int EdgeLength;
    public string[,] Fields;

    public Grid(int edgeLength)
    {
      EdgeLength = edgeLength;
      Fields = new string[edgeLength, edgeLength];
    }
  }
}
