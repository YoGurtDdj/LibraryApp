using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Patagames.Pdf.Net;
using Patagames.Pdf.Net.Controls.Wpf;
using Patagames.Pdf.Net.Controls.Wpf.ToolBars;
using System.Speech.Synthesis;
using Patagames.Pdf.Net.Controls.WinForms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Library
{
    public partial class DocumentWindow : Window
    {
        private PdfDocument pdfDocument;

        public string FilePath { get; private set; }
        public string FileName { get; private set; }

        public DocumentWindow(string fileName)
        {
            InitializeComponent();
            FilePath = fileName;
            FileName = Path.GetFileName(fileName);
            OpenFile();
        }

        private void OpenFile()
        {
            PdfCommon.Initialize();
            pdfDocument = PdfDocument.Load(FilePath);
            pdfViewer1.Document = pdfDocument;
        }



        public void onclick()
        {
            SpeechSynthesizer sound = new SpeechSynthesizer();
            string text = pdfViewer1.SelectedText;
            sound.Volume = 100;
            sound.Rate = 2;
            sound.SpeakAsync(text);
        }

    }

    public class MyToolBar : PdfToolBar
    {
        Patagames.Pdf.Net.Controls.Wpf.PdfViewer pdfViewer;
        protected override void InitializeButtons()
        {
            Button newItem = CreateButton("btnOpenDoc", "Речь", "text", CreateUriToResource("docOpen.png"), btn_Click);
            base.Items.Add(newItem);
            newItem = CreateButton("btnMakeNote", "Заметка", "text", CreateUriToResource("docOpen.png"), btn2_Click);
            base.Items.Add(newItem);
        }
        protected override void UpdateButtons()
        {
            Button button = base.Items[0] as Button;
            if (button != null)
            {
                button.IsEnabled = base.PdfViewer != null;
            }
            button = base.Items[1] as Button;
            if (button != null)
            {
                button.IsEnabled = base.PdfViewer != null;
            }
        }

        public void btn_Click(object sender, EventArgs e)
        {
            OnBtnClick(base.Items[0] as Button);
        }
        public void btn2_Click(object sender, EventArgs e)
        {
            OnBtnClick2(base.Items[1] as Button);
        }
        public void OnBtnClick(Button item)
        {
            pdfViewer = (Patagames.Pdf.Net.Controls.Wpf.PdfViewer)FindName("pdfViewer1");
            SpeechSynthesizer sound = new SpeechSynthesizer();
            string text = pdfViewer.SelectedText;
            sound.Volume = 100;
            sound.Rate = 2;
            sound.SpeakAsync(text);
        }
        public void OnBtnClick2(Button item)
        {
            string connStr = "server=localhost;user=root;database=Library;port=3307;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            DocumentWindow currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as DocumentWindow;
            
            try
            {
                conn.Open();

                pdfViewer = (Patagames.Pdf.Net.Controls.Wpf.PdfViewer)FindName("pdfViewer1");
                string text = pdfViewer.SelectedText;
                string sql = "INSERT INTO notes1(fileName, markText, user_id) VALUES (@content, @content2, @content3)";

                MySqlCommand aboba = new MySqlCommand(sql, conn);
                aboba.Parameters.AddWithValue("@content", currentWindow.FileName);
                aboba.Parameters.AddWithValue("@content2", text);
                aboba.Parameters.AddWithValue("@content3", User.UserID);
                aboba.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }
    }
}
