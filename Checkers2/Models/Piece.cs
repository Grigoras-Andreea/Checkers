using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers2.Models
{
    class Piece : BaseNotification
    {
        private bool isRed;
        private bool isKing;
        private Square square;
        private string image;

        public Piece(bool isRed, bool isKing)
        {
            this.isRed = isRed;
            this.isKing = isKing;
            if(isRed && !isKing)
            {
                image = "/Checkers2;component/Resources/RedPiece.png";
            }
            else if(isRed && isKing)
            {
                image = "/Checkers2;component/Resources/RedKing.png";
            }
            else if(!isRed && !isKing)
            {
                image = "/Checkers2;component/Resources/WhitePiece.png";
            }
            else
            {
                image = "/Checkers2;component/Resources/WhiteKing.png";
            }
        }

        public bool IsRed
        {
            get { return isRed; }
            set
            {
                isRed = value;
                NotifyPropertyChanged("IsRed");
            }
        }
        public bool IsKing
        {
            get { return isKing; }
            set
            {
                isKing = value;
                NotifyPropertyChanged("IsKing");
            }
        }
        public Square Square
        {
            get { return square; }
            set
            {
                square = value;
                NotifyPropertyChanged("Square");
            }
        }
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }
    }
}
