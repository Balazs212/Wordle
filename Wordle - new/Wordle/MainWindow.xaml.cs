using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;

namespace Wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Words words;
        public int WordLen;
        public static List<string> SelectedLen = new List<string> { };
        public bool ApiSelected = false;
        public string selectedWord;
        public string langu = "en";

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            string threeLetterFilePath = "words_3.txt";
            string fourLetterFilePath = "words_4.txt";
            string fiveLetterFilePath = "words_5.txt";
            string sixLetterFilePath = "words_6.txt";
            words = new Words();
            words.ReadWordsFromFiles(threeLetterFilePath, fourLetterFilePath, fiveLetterFilePath, sixLetterFilePath);
        }
        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberTextBox.Text, out int number))
            {
                number++;
                NumberTextBox.Text = number.ToString();
            }
            DecreaseButton.Visibility = Visibility.Visible;
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberTextBox.Text, out int number))
            {
                number--;
                NumberTextBox.Text = number.ToString();
            }
            IncreaseButton.Visibility = Visibility.Visible;
        }

        private void WordleStartButton_Click(object sender, RoutedEventArgs e)
        {
            WordLen = int.Parse(NumberTextBox.Text);
            bool ready = true;
            if (ApiSelected == false)
            {
                switch (WordLen)
                {
                    case 3:
                        SelectedLen = words.ThreeLetterWords;
                        break;
                    case 4:
                        SelectedLen = words.FourLetterWords;
                        break;
                    case 5:
                        SelectedLen = words.FiveLetterWords;
                        break;
                    case 6:
                        SelectedLen = words.SixLetterWords;
                        break;
                    default:
                        MessageBox.Show("Error");
                        ready = false;
                        break;
                }
            }
            if (ready)
            {
                MainFrame.NavigationService.Navigate(new Uri("Game.xaml", UriKind.Relative));
                WordleStartScreen.Visibility = Visibility.Collapsed;
            }
        }

        private void Len_Change(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(NumberTextBox.Text))
            {
                case 3:
                    DecreaseButton.Visibility = Visibility.Hidden;
                    break;
                case 10:
                    IncreaseButton.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
            WordLen = int.Parse(NumberTextBox.Text);
        }

        private void LanSel_Change(object sender, RoutedEventArgs e)
        {
            langu = ((ComboBoxItem)LanSel.SelectedItem).Tag.ToString();
        }

        private void ApiButton_Click(object sender, RoutedEventArgs e)
        {
            ApiSelected= true;
            using (WebClient wc = new WebClient())
            {
                var jason = wc.DownloadString($"https://random-word-api.herokuapp.com/word?length={WordLen}&lang={langu}");
                string word = "";
                foreach (char item in jason.ToString().ToLower())
                {
                    if (Char.IsLetter(item)) 
                    {
                        word += item;
                    }
                }
                selectedWord = word;
            }
            APIReadytext.Visibility = Visibility.Visible;
        }
    }
}