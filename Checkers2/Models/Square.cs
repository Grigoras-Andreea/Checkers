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
        private Piece piece;
        private string color;

        public Square(int row, int column, bool isBlack, Piece piece)
        {
            this.row = row;
            this.column = column;
            this.isBlack = isBlack;
            this.piece = piece;
            if (isBlack)
            {
                color = "#603f20";
            }
            else
            {
                color = "#e6ccb3";
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
        public Piece Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                NotifyPropertyChanged("Piece");
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


    }
}
