using Checkers2.Commands;
using Checkers2.Models;
using Checkers2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers2.ViewModels
{
    internal class GameVM
    {
        private GameBusinessLogic bl;
        public ObservableCollection<ObservableCollection<Square>> Board { get; set; }

        public GameVM()
        {
            ObservableCollection<ObservableCollection<Square>> board = Helper.InitBoard();
            Board = board;
            bl = new GameBusinessLogic(board);
        }

        private ICommand clickCommand;

        public ICommand ClickCommand
        {
            get
            {
                if(clickCommand == null)
                {
                    clickCommand = new RelayCommand<Square>(bl.SelectOrMovePiece);
                }
                return clickCommand;
            }
        }

        /*private ICommand moveCommand;

        public ICommand MoveCommand
        {
            get
            {
                if (moveCommand == null)
                {
                    moveCommand = new RelayCommand<Square>(bl.MovePiece);
                }
                return moveCommand;
            }
        }*/
    }
}
