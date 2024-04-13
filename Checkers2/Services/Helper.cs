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

        public static void SaveBoard(ObservableCollection<ObservableCollection<Square>> board, string filePath)
        {
            // Create a root-level element for the board data
            XElement root = new XElement("Board");

            // Serialize each row of squares and add them to the root element
            foreach (var row in board)
            {
                XElement rowElement = new XElement("Row");
                foreach (var square in row)
                {
                    // Serialize the square and add it to the row element
                    XElement squareElement = new XElement("Square");
                    // Add properties of square to squareElement
                    squareElement.Add(new XElement("Row", square.Row));
                    squareElement.Add(new XElement("Column", square.Column));
                    // Add piece data if square is not empty
                    if (!square.IsEmpty)
                    {
                        XElement pieceElement = new XElement("Piece");
                        pieceElement.Add(new XElement("IsRed", square.Piece.IsRed));
                        pieceElement.Add(new XElement("IsKing", square.Piece.IsKing));
                        pieceElement.Add(new XElement("Image", square.Piece.Image));
                        squareElement.Add(pieceElement);
                    }
                    rowElement.Add(squareElement);
                }
                root.Add(rowElement);
            }

            // Save the root element to the XML file
            root.Save(filePath);
        }

        public static ObservableCollection<ObservableCollection<Square>> LoadBoard(string filePath)
        {
            ObservableCollection<ObservableCollection<Square>> board;

            // Deserialize the board from XML
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ObservableCollection<Square>>));

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                board = (ObservableCollection<ObservableCollection<Square>>)serializer.Deserialize(fs);
            }

            return board;
        }

    }
}
