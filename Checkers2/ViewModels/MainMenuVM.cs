using Checkers2.Commands;
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

        public MainMenuVM()
        {
            NewGameCommand = new RelayCommand<object>(OpenNewGameWindow);
            SavedGameCommand = new RelayCommand<object>(OpenSavedGameWindow);
            StatisticsCommand = new RelayCommand<object>(OpenStatisticsWindow);
            AboutCommand = new RelayCommand<object>(OpenAboutWindow);
            LoadGame1 = new RelayCommand<object>(OpenGame1Window);
            LoadGame2 = new RelayCommand<object>(OpenGame2Window);
            LoadMainMenu = new RelayCommand<object>(OpenMainMenuWindow);
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
        }

        private void OpenStatisticsWindow(object obj)
        {
            // Logic to open the statistics window
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
