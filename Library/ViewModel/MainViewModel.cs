using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Library.Core;

namespace Library.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand MyFilesViewCommand { get; set; }
        public RelayCommand BookmarksViewCommand { get; set; }
        public RelayCommand FavouritesViewCommand { get; set; }
        public RelayCommand RegistrationViewCommand { get; set; }
        public RelayCommand AutorizationViewCommand { get; set; }
        public RelayCommand AccountViewCommand { get; set; }
        public RelayCommand NoAccountViewCommand { get; set; }

        public MyFilesViewModel MyFilesVm { get; set; }
        public BookmarksViewModel BookmarksVm { get; set; }
        public FavouritesViewModel FavouritesVm { get; set; }
        public RegistrationViewModel RegistrationVm { get; set; }
        public AutorizationViewModel AutorizationVm { get; set; }
        public AccountViewModel AccountVm { get; set; }
        public NoAccountViewModel NoAccountVm { get; set; }

        private object _currentView;
        public string _currentText;
  
        public Brush _myFilesBut = new SolidColorBrush(Colors.White);
        public Brush _bookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
        public Brush _favourutesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
        public Brush _accountBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));


        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public string CurrentText {
            get { return _currentText; } 
            set 
            { 
                _currentText = value; 
                OnPropertyChanged(); 
            }
        }
        public Brush MyFilesBut
        {
            get { return _myFilesBut; }
            set
            {
                _myFilesBut = value;
                OnPropertyChanged();
            }
        }
        public Brush BookmarksBut
        {
            get { return _bookmarksBut; }
            set
            {
                _bookmarksBut = value;
                OnPropertyChanged();
            }
        }
        public Brush FavouritesBut
        {
            get { return _favourutesBut; }
            set
            {
                _favourutesBut = value;
                OnPropertyChanged();
            }
        }
        public Brush AccountBut
        {
            get { return _accountBut; }
            set
            {
                _accountBut = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            User.UserLoggedIn += HandleUserLoggedIn;
            MyFilesVm = new MyFilesViewModel();
            BookmarksVm = new BookmarksViewModel();
            FavouritesVm = new FavouritesViewModel();
            RegistrationVm = new RegistrationViewModel();
            AutorizationVm = new AutorizationViewModel();
            AccountVm = new AccountViewModel();
            NoAccountVm = new NoAccountViewModel();
            CurrentView = MyFilesVm;
            CurrentText = "My Files";

            MyFilesViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Colors.White);
                BookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                FavouritesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                AccountBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                CurrentText = "My Files";
                CurrentView = MyFilesVm;
            });
            BookmarksViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                BookmarksBut = new SolidColorBrush(Colors.White);
                FavouritesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                AccountBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                
                if (User.IsUserLoggedIn())
                {
                    CurrentText = "Bookmarks";
                    CurrentView = BookmarksVm;
                }
                else
                {
                    CurrentText = "NoAccount";
                    CurrentView = NoAccountVm;
                }
            });
            FavouritesViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                BookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                FavouritesBut = new SolidColorBrush(Colors.White);
                AccountBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                if (User.IsUserLoggedIn())
                {
                    CurrentText = "Favourites";
                    CurrentView = FavouritesVm;
                }
                else
                {
                    CurrentText = "NoAccount";
                    CurrentView = NoAccountVm;
                }
            });
            RegistrationViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                BookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                FavouritesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                AccountBut = new SolidColorBrush(Colors.White);
                if (User.IsUserLoggedIn())
                {
                    CurrentText = "Account";
                    CurrentView = AccountVm;
                }
                else
                {
                    CurrentText = "Registration";
                    CurrentView = RegistrationVm;
                }
            });
            AutorizationViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                BookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                FavouritesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                AccountBut = new SolidColorBrush(Colors.White);
                if (User.IsUserLoggedIn())
                {
                    CurrentText = "Account";
                    CurrentView = AccountVm;
                }
                else
                {
                    CurrentText = "Authorization";
                    CurrentView = AutorizationVm;
                }

            });

        }
        private void HandleUserLoggedIn(object sender, EventArgs e)
        {
            if (User.IsUserLoggedIn())
            {
                CurrentText = "Account";
                CurrentView = AccountVm;
            }
        }
    }
}
