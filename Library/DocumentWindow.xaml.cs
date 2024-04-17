using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using PdfiumViewer;
using PdfiumViewer.Core;

namespace Library
{
    public partial class DocumentWindow : Window
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public DocumentWindow(string fileName)
        {
            InitializeComponent();
            FileName = fileName;
            FilePath = Path.GetFileName(fileName);
            PdfViewer.OpenPdf("C:/Users/islam/Documents/Library_books/sample.pdf");
        }
    }
}
