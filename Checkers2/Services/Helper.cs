using Checkers2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers2.Services
{
    internal class Helper
    {
        public static ObservableCollection<ObservableCollection<Square>> initBoard()
        {
            ObservableCollection<ObservableCollection<Square>> board = new ObservableCollection<ObservableCollection<Square>>();
            for (int i = 0; i < 8; i++)
            {
                ObservableCollection<Square> row = new ObservableCollection<Square>();
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        row.Add(new Square(i, j, false, null));
                    }
                    else
                    {
                        if (i < 3)
                        {
                            row.Add(new Square(i, j, true, new Piece(false, false)));
                        }
                        else if (i > 4)
                        {
                            row.Add(new Square(i, j, true, new Piece(true, false)));
                        }
                        else
                        {
                            row.Add(new Square(i, j, true, null));
                        }
                    }
                }
                board.Add(row);
            }
            return board;
        }
    }
}
