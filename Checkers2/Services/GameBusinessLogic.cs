using Checkers2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers2.Services
{
    internal class GameBusinessLogic
    {
        ObservableCollection<ObservableCollection<Square>> board;
        public GameBusinessLogic(ObservableCollection<ObservableCollection<Square>> board)
        {
            this.board = board;
        }

        public List<Square> GetNeighbors(Square square)
        {
            List<Square> neighbors = new List<Square>();
            int row = square.Row;
            int column = square.Column;
            if (row > 0 && column > 0)
            {
                neighbors.Add(board[row - 1][column - 1]);
            }
            if (row > 0 && column < 7)
            {
                neighbors.Add(board[row - 1][column + 1]);
            }
            if (row < 7 && column > 0)
            {
                neighbors.Add(board[row + 1][column - 1]);
            }
            if (row < 7 && column < 7)
            {
                neighbors.Add(board[row + 1][column + 1]);
            }
            return neighbors;
        }   

        public void HighlightMoves(Piece piece)
        {
            if (piece == null)
            {
                return;
            }
            Square square = piece.Square;
            List<Square> neighbors = GetNeighbors(square);
            foreach (Square neighbor in neighbors)
            {
                if (neighbor.Piece == null)
                {
                    neighbor.Color = "#ffff00";//yellow
                }
            }
        }

        public void ClickAction(Square square)
        {
            HighlightMoves(square.Piece);
        }
        

    }
}
