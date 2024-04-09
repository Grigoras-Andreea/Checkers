using Checkers2.Models;
using Checkers2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers2.ViewModels
{
    internal class GameVM
    {
        private GameBusinessLogic bl;

        public GameVM()
        {
            ObservableCollection<ObservableCollection<Square>> board = Helper.initBoard();
            bl = new GameBusinessLogic(board);
            Board = ConvertBoard(board);
        }

        private ObservableCollection<ObservableCollection<SquareVM>> ConvertBoard(ObservableCollection<ObservableCollection<Square>> board)
        {
            ObservableCollection<ObservableCollection<SquareVM>> newBoard = new ObservableCollection<ObservableCollection<SquareVM>>();
            foreach (ObservableCollection<Square> row in board)
            {
                ObservableCollection<SquareVM> newRow = new ObservableCollection<SquareVM>();
                foreach (Square square in row)
                {
                    newRow.Add(new SquareVM(square, bl));
                }
                newBoard.Add(newRow);
            }
            return newBoard;
        }
        public ObservableCollection<ObservableCollection<SquareVM>> Board { get; set;}
    }
}
