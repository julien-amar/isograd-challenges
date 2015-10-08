using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsoGrad
{
    class Program
    {
        public enum CellState
        {
            Live,
            Dead,
        };

        static CellState GetCellState(IEnumerable<Cell> cells, int x, int y)
        {
            var cell = cells
                .Where(c => c.X == x)
                .Where(c => c.Y == y)
                .Where(c => c.State == CellState.Live);

            return cell.Any() ? CellState.Live : CellState.Dead;
        }

        static List<Cell> Process(List<Cell> cells)
        {
            var width = cells.Max(x => x.X);
            var height = cells.Max(x => x.Y);

            for (int y = height; y >= 0; --y)
                for (int x = width; x >= 0; --x)
                {
                    var right = GetCellState(cells, x + 1, y);
                    var bottom = GetCellState(cells, x, y + 1);

                    if (right == CellState.Live && bottom == CellState.Live)
                    {
                        cells.Add(new Cell(x, y, CellState.Live));
                    }
                    else if (right == CellState.Dead && bottom == CellState.Dead)
                    {
                        var cell = cells.FirstOrDefault(c => c.X == x && c.Y == y);

                        if (cell != null)
                            cell.State = CellState.Dead;
                    }
                }

            return cells;
        }

        static void Main(string[] args)
        {
            var stream = Console.In;

            // Ligne 1 : un entier **N** compris entre 1 et 1 000 représentant le nombre de rectangles.  
            var nbRectangle = int.Parse(stream.ReadLine());

            // Lignes 2 à **N** + 1 : quatre nombres entiers **x1 y1 x2 y2** chacun compris entre 1 et 1 000 000 et séparés par des espaces.
            // Touts les points inclus dans le rectangle délimité par **x1**, **y1** (coin haut-gauche) et **x2**, **y2** (coin bas-droite) sont des cellules vivantes.
            // En effet, les abscisses vont croissant vers la droite, et les ordonnées vont croissant vers le bas.  
            var cellPacks = (from i in Enumerable.Range(0, nbRectangle)
                       let line = stream.ReadLine().Split(new[] { ' ' }).Select(int.Parse).Select(x => x - 1).ToArray()
                       select new
                       {
                           X1 = line[0],
                           Y1 = line[1],
                           X2 = line[2],
                           Y2 = line[3],
                       })
                       .Select(cell =>
                       {
                           var result = new List<Cell>();
                       for (int y = cell.Y1; y <= cell.Y2; ++y)
                           for (int x = cell.X1; x <= cell.X2; ++x)
                               result.Add(new Cell(x, y, CellState.Live));
                           return result;
                       })
                       .SelectMany(x => x)
                       .ToList();


             Process(cellPacks);
        }

        public class Cell
        {
            public Cell(int x, int y, CellState state)
            {
                X = x;
                Y = y;
                State = state;
            }

            public CellState State { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
