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

        public MyFilesViewModel MyFilesVm { get; set; }
        public BookmarksViewModel BookmarksVm { get; set; }
        public FavouritesViewModel FavouritesVm { get; set; }

        private object _currentView;
        public string _currentText;
  
        public Brush _myFilesBut = new SolidColorBrush(Colors.White);
        public Brush _bookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
        public Brush _favourutesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));

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

        public MainViewModel()
        {
            MyFilesVm = new MyFilesViewModel();
            BookmarksVm = new BookmarksViewModel();
            FavouritesVm = new FavouritesViewModel();
            CurrentView = MyFilesVm;
            CurrentText = "My Files";

            MyFilesViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Colors.White);
                BookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                FavouritesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                CurrentText = "My Files";
                CurrentView = MyFilesVm;
            });
            BookmarksViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                BookmarksBut = new SolidColorBrush(Colors.White);
                FavouritesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                CurrentText = "Bookmarks";
                CurrentView = BookmarksVm;
            });
            FavouritesViewCommand = new RelayCommand(o =>
            {
                MyFilesBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                BookmarksBut = new SolidColorBrush(Color.FromRgb(57, 57, 57));
                FavouritesBut = new SolidColorBrush(Colors.White);
                CurrentText = "Favourites";
                CurrentView = FavouritesVm;
            });
        }
    }
}
