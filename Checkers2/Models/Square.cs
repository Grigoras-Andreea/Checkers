using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers2.Models
{
    internal class Square : BaseNotification
    {
        private int row;
        private int column;
        private bool isBlack;
        private string color;
        private Piece piece;
        private bool isEmpty;

        public Square(int row, int column, bool isBlack, Piece piece)
        {
            this.row = row;
            this.column = column;
            this.isBlack = isBlack;
            if (isBlack)
            {
                color = "#603f20";
            }
            else
            {
                color = "#e6ccb3";
            }

            this.piece = piece;
            if(piece.IsNull)
            {
                isEmpty = true;
            }
            else
            {
                isEmpty = false;
            }
        }

        public int Row
        {
            get { return row; }
            set
            {
                row = value;
                NotifyPropertyChanged("Row");
            }
        }
        public int Column
        {
            get { return column; }
            set
            {
                column = value;
                NotifyPropertyChanged("Column");
            }
        }
        public bool IsBlack
        {
            get { return isBlack; }
            set
            {
                isBlack = value;
                NotifyPropertyChanged("IsBlack");
            }
        }
        
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                NotifyPropertyChanged("Color");
            }
        }

        public Piece Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                NotifyPropertyChanged("Piece");
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                isEmpty = value;
                NotifyPropertyChanged("IsEmpty");
            }
        }

    }
}
