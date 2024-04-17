using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BookmarksView.xaml
    /// </summary>
    public partial class BookmarksView : UserControl
    {
        public BookmarksView()
        {
            InitializeComponent();
            ShowMarks();
        }

        private void ShowMarks()
        {
            Bookmarks.BookmarksList.Add(new Bookmark("dw", this));
            Bookmarks.BookmarksList.Add(new Bookmark("dw", this));
            foreach (var i in Bookmarks.BookmarksList)
            {
                Files.Children.Add(i);
            }
        }

        public void RefreshUI()
        {
            Files.Children.Clear();
            ShowMarks();
        }
    }
}
