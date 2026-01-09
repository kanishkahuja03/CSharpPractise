using System;

namespace AdvancedOOPS
{
    // Generic Point class
    public class Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        // Overload + operator for numeric points
        public static Point<T> operator +(Point<T> a, Point<T> b)
        {
            dynamic dx = a.X;
            dynamic dy = a.Y;
            dynamic bx = b.X;
            dynamic by = b.Y;
            return new Point<T>(dx + bx, dy + by);
        }

        public override string ToString() => $"({X},{Y})";
    }

    // Generic Grid class with indexer
    public class Grid<T>
    {
        private T[,] _cells;

        public Grid(int rows, int cols)
        {
            _cells = new T[rows, cols];
        }

        // Indexer
        public T this[int row, int col]
        {
            get => _cells[row, col];
            set => _cells[row, col] = value;
        }

        public int Rows => _cells.GetLength(0);
        public int Cols => _cells.GetLength(1);
    }

    // Extension method for printing grid
    public static class GridExtensions
    {
        public static void PrintGrid<T>(this Grid<T> grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Cols; c++)
                {
                    Console.Write(grid[r, c] + "  ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a 2x2 grid of Points
            var grid = new Grid<Point<int>>(2, 2);

            // Assign points using the indexer
            grid[0, 0] = new Point<int>(1, 1);
            grid[0, 1] = new Point<int>(2, 2);
            grid[1, 0] = new Point<int>(3, 3);
            grid[1, 1] = new Point<int>(4, 4);

            Console.WriteLine("Original Grid:");
            grid.PrintGrid();  // Extension method

            // Add two points and store result in grid
            grid[0, 0] = grid[0, 0] + grid[1, 1];

            Console.WriteLine("\nGrid after adding (0,0) + (1,1):");
            grid.PrintGrid();  // Extension method
        }
    }
}
