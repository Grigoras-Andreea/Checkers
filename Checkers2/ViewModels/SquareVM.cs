using Checkers2.Commands;
using Checkers2.Models;
using Checkers2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers2.ViewModels
{
    internal class SquareVM : BaseNotification
    {
        private Square square;
        private ICommand clickCommand;
        //private ICommand moveCommand;
        private GameBusinessLogic bl;

        public SquareVM(Square square, GameBusinessLogic bl)
        {
            this.square = square;
            this.bl = bl;
            SimpleSquare = square;

        }

        public string Image
        {
            get { return square.Piece?.Image; }
            
        }

        public string Color
        {
            get { return square.Color; }
            set
            {
                square.Color = value;
                NotifyPropertyChanged("Color Change");
            }
        }

        public Square SimpleSquare { get; set; }

        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand<Square>(bl.ClickAction);
                }
                return clickCommand;
            }
        }

        
    }
}
