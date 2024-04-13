using Checkers2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

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

        public static void SaveBoard(ObservableCollection<ObservableCollection<Square>> board, int turn, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the current turn
                writer.WriteLine(turn);

                // Write the board state
                foreach (var row in board)
                {
                    foreach (var square in row)
                    {
                        writer.WriteLine($"{square.Row},{square.Column},{square.IsBlack},{square.Piece.IsRed},{square.Piece.IsKing},{square.Piece.IsNull}");
                    }
                }
            }
        }

        public static Tuple<ObservableCollection<ObservableCollection<Square>>, int> LoadBoard(string filePath)
        {
            ObservableCollection<ObservableCollection<Square>> board = new ObservableCollection<ObservableCollection<Square>>();
            int turn = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the current turn
                turn = int.Parse(reader.ReadLine());

                // Read the board state
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int row = int.Parse(parts[0]);
                    int column = int.Parse(parts[1]);
                    bool isBlack = bool.Parse(parts[2]);
                    bool isRed = bool.Parse(parts[3]);
                    bool isKing = bool.Parse(parts[4]);
                    bool isNull = bool.Parse(parts[5]);

                    Piece piece = new Piece(isRed, isKing, isNull);
                    Square square = new Square(row, column, isBlack, piece);

                    if (board.Count <= row)
                    {
                        board.Add(new ObservableCollection<Square>());
                    }

                    board[row].Add(square);
                }
            }

            return Tuple.Create(board, turn);
        }

        public Tuple<int, int, List<string>> GetResults(string filePath)
        {
            int player1Score = 0;
            int player2Score = 0;
            List<string> results = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Assuming each line format is "Winner: Player X, Date: ..."
                    // Extracting the winner
                    int startIndex = line.IndexOf("Winner: ") + "Winner: ".Length;
                    int commaIndex = line.IndexOf(",", startIndex);
                    string winner = line.Substring(startIndex, commaIndex - startIndex).Trim();

                    // Updating scores based on the winner
                    if (winner == "Player 1")
                        player1Score++;
                    else if (winner == "Player 2")
                        player2Score++;

                    // Adding the result to the list
                    results.Add(line);
                }
            }

            return Tuple.Create(player1Score, player2Score, results);
        }

    }
}
