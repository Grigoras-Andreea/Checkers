using Checkers2.Models;
using Checkers2.ViewModels;
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
        private ObservableCollection<ObservableCollection<Square>> board;

        Square source;
        int turn = 0;

        public ObservableCollection<ObservableCollection<Square>> Board
        {
            get { return board; }
            set
            {
                board = value;
                NotifyPropertyChanged("Board");
            }
        }
        public GameBusinessLogic(ObservableCollection<ObservableCollection<Square>> board)
        {
            Board = board;
        }
        public ObservableCollection<Square> GetNeighbors(Square square)
        {
            if(!square.Piece.IsNull)
            {
                if (square.Piece.IsKing)
                {
                    return GetKingNeighbors(square);
                }
                else if (square.Piece.IsRed)
                {
                    return GetRedNeighbors(square);
                }
                else
                {
                    return GetWhiteNeighbors(square);
                }
            }
            return null;
        }

        private ObservableCollection<Square> GetKingNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = new ObservableCollection<Square>();
            int row = square.Row;
            int column = square.Column;

            // Check top-left neighbor
            if (row > 0 && column > 0)
            {
                Square topLeftNeighbor = Board[row - 1][column - 1];
                if (topLeftNeighbor != null && topLeftNeighbor.Piece.IsNull)
                    neighbors.Add(topLeftNeighbor);
            }

            // Check top-right neighbor
            if (row > 0 && column < 7)
            {
                Square topRightNeighbor = Board[row - 1][column + 1];
                if (topRightNeighbor != null && topRightNeighbor.Piece.IsNull)
                    neighbors.Add(topRightNeighbor);
            }

            // Check bottom-left neighbor
            if (row < 7 && column > 0)
            {
                Square bottomLeftNeighbor = Board[row + 1][column - 1];
                if (bottomLeftNeighbor != null && bottomLeftNeighbor.Piece.IsNull)
                    neighbors.Add(bottomLeftNeighbor);
            }

            // Check bottom-right neighbor
            if (row < 7 && column < 7)
            {
                Square bottomRightNeighbor = Board[row + 1][column + 1];
                if (bottomRightNeighbor != null && bottomRightNeighbor.Piece.IsNull)
                    neighbors.Add(bottomRightNeighbor);
            }

            return neighbors;
        }


        private ObservableCollection<Square> GetWhiteNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = new ObservableCollection<Square>();
            int row = square.Row;
            int column = square.Column;

            // Check bottom-left neighbor
            if (row < 7 && column > 0)
            {
                Square bottomLeftNeighbor = Board[row + 1][column - 1];
                if (bottomLeftNeighbor.Piece != null && bottomLeftNeighbor.Piece.IsNull)
                    neighbors.Add(bottomLeftNeighbor);
            }

            // Check bottom-right neighbor
            if (row < 7 && column < 7)
            {
                Square bottomRightNeighbor = Board[row + 1][column + 1];
                if (bottomRightNeighbor.Piece != null && bottomRightNeighbor.Piece.IsNull)
                    neighbors.Add(bottomRightNeighbor);
            }

            return neighbors;
        }

        private ObservableCollection<Square> GetRedNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = new ObservableCollection<Square>();
            int row = square.Row;
            int column = square.Column;

            // Check top-left neighbor
            if (row > 0 && column > 0)
            {
                Square topLeftNeighbor = Board[row - 1][column - 1];
                if (topLeftNeighbor.Piece == null || topLeftNeighbor.Piece.IsNull)
                    neighbors.Add(topLeftNeighbor);
            }

            // Check top-right neighbor
            if (row > 0 && column < 7)
            {
                Square topRightNeighbor = Board[row - 1][column + 1];
                if (topRightNeighbor.Piece == null || topRightNeighbor.Piece.IsNull)
                    neighbors.Add(topRightNeighbor);
            }

            return neighbors;
        }

        public ObservableCollection<Square> HighlightNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = GetNeighbors(square);
            if (neighbors != null)
            {
                foreach (Square neighbor in neighbors)
                {
                    // Check if the neighbor is empty
                    if (neighbor.Piece == null || neighbor.Piece.IsNull)
                    {
                        // Highlight the neighbor by changing its color
                        neighbor.Color = "#ff0000"; // Red color
                    }
                }
            }
            return neighbors;
        }

        public ObservableCollection<Square> GetJumpNeighbors(Square square)
        {
            if (!square.Piece.IsNull)
            {
                if (square.Piece.IsKing && !square.Piece.IsRed)
                {
                    return GetWhiteKingJumpNeighbors(square);
                }
                else if (square.Piece.IsKing && square.Piece.IsRed)
                {
                    return GetRedKingJumpNeighbors(square);
                }
                else if (square.Piece.IsRed)
                {
                    return GetRedJumpNeighbors(square);
                }
                else
                {
                    return GetWhiteJumpNeighbors(square);
                }
            }
            return null;
        }

        private ObservableCollection<Square> GetWhiteKingJumpNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = new ObservableCollection<Square>();
            int row = square.Row;
            int column = square.Column;

            // Check top-left neighbor
            if (row > 1 && column > 1)
            {
                Square topLeftNeighbor = Board[row - 1][column - 1];
                if (!topLeftNeighbor.Piece.IsNull && topLeftNeighbor.Piece.IsRed && Board[row - 2][column - 2].Piece.IsNull)
                    neighbors.Add(Board[row - 2][column - 2]);
            }

            // Check top-right neighbor
            if (row > 1 && column < 6)
            {
                Square topRightNeighbor = Board[row - 1][column + 1];
                if (!topRightNeighbor.Piece.IsNull && topRightNeighbor.Piece.IsRed && Board[row - 2][column + 2].Piece.IsNull)
                    neighbors.Add(Board[row - 2][column + 2]);
            }

            // Check bottom-left neighbor
            if (row < 6 && column > 1)
            {
                Square bottomLeftNeighbor = Board[row + 1][column - 1];
                if (!bottomLeftNeighbor.Piece.IsNull && bottomLeftNeighbor.Piece.IsRed && Board[row + 2][column - 2].Piece.IsNull)
                    neighbors.Add(Board[row + 2][column - 2]);
            }

            // Check bottom-right neighbor
            if (row < 6 && column < 6)
            {
                Square bottomRightNeighbor = Board[row + 1][column + 1];
                if (!bottomRightNeighbor.Piece.IsNull && bottomRightNeighbor.Piece.IsRed && Board[row + 2][column + 2].Piece.IsNull)
                    neighbors.Add(Board[row + 2][column + 2]);
            }

            return neighbors;
        }

        private ObservableCollection<Square> GetRedKingJumpNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = new ObservableCollection<Square>();
            int row = square.Row;
            int column = square.Column;

            // Check top-left neighbor
            if (row > 1 && column > 1)
            {
                Square topLeftNeighbor = Board[row - 1][column - 1];
                if (!topLeftNeighbor.Piece.IsNull && !topLeftNeighbor.Piece.IsRed && Board[row - 2][column - 2].Piece.IsNull)
                    neighbors.Add(Board[row - 2][column - 2]);
            }

            // Check top-right neighbor
            if (row > 1 && column < 6)
            {
                Square topRightNeighbor = Board[row - 1][column + 1];
                if (!topRightNeighbor.Piece.IsNull && !topRightNeighbor.Piece.IsRed && Board[row - 2][column + 2].Piece.IsNull)
                    neighbors.Add(Board[row - 2][column + 2]);
            }

            // Check bottom-left neighbor
            if (row < 6 && column > 1)
            {
                Square bottomLeftNeighbor = Board[row + 1][column - 1];
                if (!bottomLeftNeighbor.Piece.IsNull && !bottomLeftNeighbor.Piece.IsRed && Board[row + 2][column - 2].Piece.IsNull)
                    neighbors.Add(Board[row + 2][column - 2]);
            }

            // Check bottom-right neighbor
            if (row < 6 && column < 6)
            {
                Square bottomRightNeighbor = Board[row + 1][column + 1];
                if (!bottomRightNeighbor.Piece.IsNull && !bottomRightNeighbor.Piece.IsRed && Board[row + 2][column + 2].Piece.IsNull)
                    neighbors.Add(Board[row + 2][column + 2]);
            }

            return neighbors;
        }

        private ObservableCollection<Square> GetWhiteJumpNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = new ObservableCollection<Square>();
            int row = square.Row;
            int column = square.Column;

            // Check bottom-left neighbor
            if (row < 6 && column > 1)
            {
                Square bottomLeftNeighbor = Board[row + 1][column - 1];
                if (!bottomLeftNeighbor.Piece.IsNull && bottomLeftNeighbor.Piece.IsRed && Board[row + 2][column - 2].Piece.IsNull)
                    neighbors.Add(Board[row + 2][column - 2]);
            }

            // Check bottom-right neighbor
            if (row < 6 && column < 6)
            {
                Square bottomRightNeighbor = Board[row + 1][column + 1];
                if (!bottomRightNeighbor.Piece.IsNull && bottomRightNeighbor.Piece.IsRed && Board[row + 2][column + 2].Piece.IsNull)
                    neighbors.Add(Board[row + 2][column + 2]);
            }

            return neighbors;
        }

        private ObservableCollection<Square> GetRedJumpNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = new ObservableCollection<Square>();
            int row = square.Row;
            int column = square.Column;

            // Check top-left neighbor
            if (row > 1 && column > 1)
            {
                Square topLeftNeighbor = Board[row - 1][column - 1];
                if (!topLeftNeighbor.Piece.IsNull && !topLeftNeighbor.Piece.IsRed && Board[row - 2][column - 2].Piece.IsNull)
                    neighbors.Add(Board[row - 2][column - 2]);
            }

            // Check top-right neighbor
            if (row > 1 && column < 6)
            {
                Square topRightNeighbor = Board[row - 1][column + 1];
                if (!topRightNeighbor.Piece.IsNull && !topRightNeighbor.Piece.IsRed && Board[row - 2][column + 2].Piece.IsNull)
                    neighbors.Add(Board[row - 2][column + 2]);
            }

            return neighbors;
        }

        public ObservableCollection<Square> HighlightJumpNeighbors(Square square)
        {
            ObservableCollection<Square> neighbors = GetJumpNeighbors(square);
            if (neighbors != null)
            {
                foreach (Square neighbor in neighbors)
                {
                    // Check if the neighbor is empty
                    if (neighbor.Piece == null || neighbor.Piece.IsNull)
                    {
                        // Highlight the neighbor by changing its color
                        neighbor.Color = "#00ff00"; // Red color
                    }
                }
            }
            return neighbors;
        }

        public void ResetBoard()
        {
            foreach (ObservableCollection<Square> row in Board)
            {
                foreach (Square square in row)
                {
                    if (square.Color == "#ff0000" || square.Color == "#00ff00")
                    {
                        square.Color = "#603f20"; // Black color
                    }
                }
            }
            source = null;
        }

        public void UpdateBoardWithNeighbors(Square square)
        {
            ResetBoard();
            source = square;
            ObservableCollection<Square> neighbors = HighlightNeighbors(square);
            if (neighbors != null)
            {
                foreach (Square neighbor in neighbors)
                {
                    // Update the square on the board with the values of the neighbor
                    Board[neighbor.Row][neighbor.Column].Color = neighbor.Color;
                }
            }

        }

        public void UpdateBoardWithJumpNeighbors(Square square)
        {
            source = square;
            ObservableCollection<Square> neighbors = HighlightJumpNeighbors(square);
            if (neighbors != null)
            {
                foreach (Square neighbor in neighbors)
                {
                    // Update the square on the board with the values of the neighbor
                    Board[neighbor.Row][neighbor.Column].Color = neighbor.Color;
                }
            }
        }

        public bool IsSelected()
        {
            if (source != null)
            {

                //checks if there is a square with color red
                foreach (ObservableCollection<Square> row in Board)
                {
                    foreach (Square square in row)
                    {
                        if (square.Color == "#ff0000" || square.Color == "#00ff00")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void TransformPiece(Square square)
        {
            if (square.Piece.IsRed && square.Row == 0)
            {
                square.Piece.IsKing = true;
                square.Piece.Image = "/Checkers2;component/Resources/RedKing.png";
            }
            else if (!square.Piece.IsRed && square.Row == 7)
            {
                square.Piece.IsKing = true;
                square.Piece.Image = "/Checkers2;component/Resources/WhiteKing.png";
            }
        }

        public void MovePiece(Square destination)
        {
            if (IsSelected())
            {
                // Check if the destination square is highlighted
                if (destination.Color == "#ff0000")
                {
                    // Move the piece to the destination square
                    destination.Piece = source.Piece;
                    destination.Color = source.Color;

                    // Clear the source square
                    source.Piece = new Piece(false, true, true);
                    source.Color = "#603f20";

                    // Reset board colors
                    ResetBoard();
                    TransformPiece(destination);
                }
                else if (destination.Color == "#00ff00")
                {
                    // Move the piece to the destination square
                    destination.Piece = source.Piece;
                    destination.Color = source.Color;

                    // Clear the source square
                    source.Piece = new Piece(false, true, true);
                    source.Color = "#603f20";

                    // Clear the jumped piece
                    int row = (source.Row + destination.Row) / 2;
                    int column = (source.Column + destination.Column) / 2;
                    Board[row][column].Piece = new Piece(false, true, true);
                    Board[row][column].Color = "#603f20";

                    // Reset board colors
                    ResetBoard();
                    TransformPiece(destination);
                }
            }
        }

        public void SelectOrMovePiece(Square square)
        {
            if(source == null)
            {
                UpdateBoardWithNeighbors(square);
                UpdateBoardWithJumpNeighbors(square);
            }
            else
            {
                 if (square.Color == "#ff0000" || square.Color == "#00ff00")
                 {
                    MovePiece(square);
                 }
                 else
                 {
                    UpdateBoardWithNeighbors(square);
                    UpdateBoardWithJumpNeighbors(square);
                 }
            }

        }

    }
}
