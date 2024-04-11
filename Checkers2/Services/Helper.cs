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
        public static ObservableCollection<ObservableCollection<Square>> InitBoard()
        {
            ObservableCollection<ObservableCollection<Square>> board = new ObservableCollection<ObservableCollection<Square>>();

            for (int i = 0; i < 8; i++)
            {
                ObservableCollection<Square> row = new ObservableCollection<Square>();

                for (int j = 0; j < 8; j++)
                {
                    bool isBlack = (i + j) % 2 == 1; // Alternating black and white squares

                    // Setting up pieces on initial positions
                    Piece piece;
                    if (isBlack)
                    {
                        if (i < 3)
                        {
                            //white pieces
                            piece = new Piece(false, false, false);
                        }
                        else if (i > 4)
                        {
                            //red pieces
                            piece = new Piece(true, false, false);
                        }
                        else
                        {
                            // Empty squares
                            piece = new Piece(false, true, true);
                        }
                    }
                    else
                    {
                        piece = new Piece(false, true, true);
                    }

                    // Creating the square
                    Square square = new Square(i, j, isBlack, piece);
                    row.Add(square);
                }
                board.Add(row);
            }

            return board;
        }
    }
}
