﻿using Checkers2.Commands;
using Checkers2.Models;
using Checkers2.Services;
using Checkers2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers2.ViewModels
{
    internal class SavedGameVM : BaseNotification
    {
        private GameBusinessLogic bl;
        public ObservableCollection<ObservableCollection<Square>> Board { get; set; }
        public ICommand MainMenuCommand { get; }
        public ICommand SaveGameCommand { get; }


        private int player1Score = 12;
        private int player2Score = 12;

        public int Player1Score
        {
            get { return player1Score; }
            set
            {
                player1Score = value;
                NotifyPropertyChanged("Player1Score");
            }
        }

        public int Player2Score
        {
            get { return player2Score; }
            set
            {
                player2Score = value;
                NotifyPropertyChanged("Player2Score");
            }
        }

        private bool isPlayer1Turn = true;

        public bool IsPlayer1Turn
        {
            get { return isPlayer1Turn; }
            set
            {
                isPlayer1Turn = value;
                NotifyPropertyChanged("IsPlayer1Turn");
            }
        }

        private string gameStatus;

        public string GameStatus
        {
            get { return gameStatus; }
            set
            {
                gameStatus = value;
                NotifyPropertyChanged("GameStatus");
            }
        }

        public SavedGameVM()
        {
            ObservableCollection<ObservableCollection<Square>> board = Helper.InitBoard();
            Board = board;
            bl = new GameBusinessLogic(board);
            bl.PropertyChanged += Bl_PropertyChanged;
            MainMenuCommand = new RelayCommand<object>(OpenMainMenuWindow);

        }

        private void Bl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Player1Score")
            {
                Player1Score = bl.Player1Score;
            }
            else if (e.PropertyName == "Player2Score")
            {
                Player2Score = bl.Player2Score;
            }
            if (e.PropertyName == "IsPlayer1Turn")
            {
                IsPlayer1Turn = bl.Turn == 0;
            }
            if (e.PropertyName == "GameStatus")
            {
                GameStatus = bl.GameStatus;
            }
        }


        private ICommand clickCommand;

        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand<Square>(bl.SelectOrMovePiece);
                }
                return clickCommand;
            }
        }

        private void OpenMainMenuWindow(object obj)
        {
            var mainMenuWindow = new MainMenu();
            mainMenuWindow.Show();
        }
    }
}