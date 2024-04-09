using Checkers2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers2.ViewModels
{
    internal class SquareVM : INotifyPropertyChanged
    {
        private Square square;

        public SquareVM(Square square)
        {
            this.square = square;
            // Subscribe to property changed event of the Square
            this.square.PropertyChanged += Square_PropertyChanged;
        }

        private void Square_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Forward property changed event to listeners
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        // Expose properties needed for binding in the UI
        public string Image
        {
            get { return square.Piece?.Image; } // Get image from the Piece if it exists
        }

        public string Color
        {
            get { return square.Color; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
