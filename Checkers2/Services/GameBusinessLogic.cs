using Checkers2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers2.Services
{
    internal class GameBusinessLogic : BaseNotification
    {
        ObservableCollection<ObservableCollection<Square>> board;
        public GameBusinessLogic(ObservableCollection<ObservableCollection<Square>> board)
        {
            this.board = board;
        }

        public ObservableCollection<ObservableCollection<Square>> Board
        {
            get { return board; }
            set
            {
                board = value;
                NotifyPropertyChanged("Board");
            }
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
                    neighbor.Color = "#000000";
                    board[neighbor.Row][neighbor.Column].Color = "#000000";
                }
            }
        }

        public void ClickAction(Square square)
        {
            square.Piece.Square = square;
            HighlightMoves(square.Piece);

        }

    }
}
