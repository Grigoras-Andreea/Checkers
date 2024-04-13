using Checkers2.Commands;
using Checkers2.Services;
using Checkers2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers2.ViewModels
{
    internal class MainMenuVM
    {
        public ICommand NewGameCommand { get; }
        public ICommand SavedGameCommand { get; }
        public ICommand StatisticsCommand { get; }
        public ICommand AboutCommand { get; }
        public ICommand LoadGame1 {  get; }
        public ICommand LoadGame2 { get; }
        public ICommand LoadMainMenu { get; }
        public ICommand LoadSavedGame1 { get; }
        public ICommand LoadSavedGame2 { get; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public List<string> Games { get; set; }

        public MainMenuVM()
        {
            NewGameCommand = new RelayCommand<object>(OpenNewGameWindow);
            SavedGameCommand = new RelayCommand<object>(OpenSavedGameWindow);
            StatisticsCommand = new RelayCommand<object>(OpenStatisticsWindow);
            AboutCommand = new RelayCommand<object>(OpenAboutWindow);
            LoadGame1 = new RelayCommand<object>(OpenGame1Window);
            LoadGame2 = new RelayCommand<object>(OpenGame2Window);
            LoadMainMenu = new RelayCommand<object>(OpenMainMenuWindow);
            LoadSavedGame1 = new RelayCommand<object>(OpenSavedGame1Window);
            LoadSavedGame2 = new RelayCommand<object>(OpenSavedGame2Window);

            Helper helper = new Helper();

            // Call GetResults to retrieve scores and list
            var results = helper.GetResults("D:\\Scoala\\anul2\\sem2\\MAP\\Checkers2\\Checkers2\\Resources\\Statistics.txt");
            Player1Score = results.Item1;
            Player2Score = results.Item2;
            Games = results.Item3;

        }

        private void OpenSavedGame2Window(object obj)
        {
            var savedGameWindow2 = new SavedGameWindow2();
            savedGameWindow2.Show();
        }

        private void OpenSavedGame1Window(object obj)
        {
            var savedGameWindow = new SavedGameWindow();
            savedGameWindow.Show();
        }

        private void OpenMainMenuWindow(object obj)
        {
            var mainMenuWindow = new MainMenu();
            mainMenuWindow.Show();
        }

        private void OpenGame2Window(object obj)
        {
            var game2Window = new MainWindow2();
            game2Window.Show();
        }

        private void OpenGame1Window(object obj)
        {
            var game1Window = new MainWindow();
            game1Window.Show();
        }

        private void OpenNewGameWindow(object obj)
        {
            // Instantiate the GameMenu window
            var gameMenuWindow = new GameMenu();

            // Show the GameMenu window
            gameMenuWindow.Show();
            
        }

        private void OpenSavedGameWindow(object obj)
        {
            // Logic to open the saved game window
            var savedGameWindow = new LoadSavedGameMenu();
            savedGameWindow.Show();
        }

        private void OpenStatisticsWindow(object obj)
        {
            var statisticsWindow = new Statistics();
            statisticsWindow.Show();
        }

        private void OpenAboutWindow(object obj)
        {
            // Logic to open the about window
            var aboutWindow = new About();
            aboutWindow.Show();
        }
    }
}
