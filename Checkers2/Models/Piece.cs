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
        private string image;
        private bool isNull;

        public Piece(bool isRed, bool isKing, bool isNull)
        {
            this.isRed = isRed;
            this.isKing = isKing;
            this.isNull = isNull;
            if (isNull)
            {
                image = "/Checkers2;component/Resources/Transparent.png";
            }
            else if (isRed)
            {
                if (isKing)
                {
                    image = "/Checkers2;component/Resources/RedKing.png";
                }
                else
                {
                    image = "/Checkers2;component/Resources/RedPiece.png";
                }
            }
            else
            {
                if (isKing)
                {
                    image = "/Checkers2;component/Resources/WhiteKing.png";
                }
                else
                {
                    image = "/Checkers2;component/Resources/WhitePiece.png";
                }
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
        
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }
        public bool IsNull
        {
            get { return isNull; }
            set
            {
                isNull = value;
                NotifyPropertyChanged("IsNull");
            }
        }
    }
}
