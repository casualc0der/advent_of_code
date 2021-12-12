public class Print
{
  public static void Octopi(int[,] octopiGrid, int height, int width)
  {
    for (int h = 0; h < height; h++)
    {
      Console.Write('\n');
      for (int w = 0; w < width; w++)
      {
        Console.Write(octopiGrid[h, w].ToString().PadRight(3, ' '));
      }
    }
    Console.Write('\n');
  }
}