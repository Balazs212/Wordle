using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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

namespace Wordle
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public delegate void NavigateBackDelegate();
        public event NavigateBackDelegate NavigateBackRequested;
        int letterCounter = 0; int rows = 0;
        List<char> KeyboardLetters = new List<char>
        {
            'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P',
            'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L',
            'Z', 'X', 'C', 'V', 'B', 'N', 'M'
        };
        List<Button> KeyboardList = new List<Button>();
        List<Button> SelectedKeyboardList = new List<Button>();
        List<TextBox> TextBoxes = new List<TextBox>();
        List<TextBox> selectedTextBoxes = new List<TextBox>();
        string currentWord = "";
        Random random = new Random();
        public Game()
        {
            InitializeComponent();
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow.ApiSelected == false)
            {
                mainWindow.selectedWord = MainWindow.SelectedLen[random.Next(MainWindow.SelectedLen.Count)];
            }



            for (int i = 0; i < 6; i++)
            {
                StackPanel row = new StackPanel();
                row.Orientation = Orientation.Horizontal;
                row.HorizontalAlignment = HorizontalAlignment.Center;
                MainPanel.Children.Add(row);
                for (int j = 0; j < mainWindow.WordLen; j++)
                {
                    TextBox character = new TextBox();
                    character.IsReadOnly = true;
                    character.Width = 35;
                    character.Height = 35;
                    character.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    character.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                    character.Background = Brushes.Black;
                    character.Foreground = Brushes.White;
                    character.FontFamily = new FontFamily("Arial");
                    character.Margin = new System.Windows.Thickness(4);
                    character.Tag = $"Row{i}";
                    TextBoxes.Add(character);
                    StackPanel BottomRow = MainPanel.Children[MainPanel.Children.Count - 1] as StackPanel;
                    BottomRow.Children.Add(character);

                }
            }

            for (int i = 0; i < KeyboardLetters.Count(); i++)
            {
                StackPanel currentRow = qRow;
                if (i<10)
                {
                    currentRow = qRow;

                }
                if (i>=10 && i < 19)
                {
                    currentRow = aRow;

                }
                if (i>=19)
                {
                    currentRow = zRow;
                }
                Button letter = new Button();
                letter.Width = 40;
                letter.Height = 40;
                letter.Content = KeyboardLetters[i];
                letter.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                letter.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                letter.Background = Brushes.Gray;
                letter.Foreground = Brushes.White;
                letter.FontFamily = new FontFamily("Arial");
                letter.Margin = new System.Windows.Thickness(5);
                letter.Click += Input_;
                KeyboardList.Add(letter);
                currentRow.Children.Add(letter);

            }
                StackPanel enterRow = aRow;
            Button enter = new Button();
            enter.Width = 80;
            enter.Height = 40;
            enter.Content = "Enter";
            enter.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            enter.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            enter.Background = Brushes.DarkGreen;
            enter.Foreground = Brushes.White;
            enter.FontFamily = new FontFamily("Arial");
            enter.Margin = new System.Windows.Thickness(5);
            enter.Click += Enter_;
            enterRow.Children.Add(enter);

            StackPanel deleteRow = zRow;
            Button delete = new Button();
            delete.Width = 80;
            delete.Height = 40;
            delete.Content = "Delete";
            delete.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            delete.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            delete.Background = Brushes.DarkRed;
            delete.Foreground = Brushes.White;
            delete.FontFamily = new FontFamily("Arial");
            delete.Margin = new System.Windows.Thickness(5);
            delete.Click += Delete_;
            deleteRow.Children.Add(delete);

            for (int i = 0; i < mainWindow.WordLen; i++)
            {
                TextBoxes[i].Background = Brushes.Gray;
            }
        }
        private void Input_(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            Button currentLetter = sender as Button;
            if (currentWord.Length < mainWindow.WordLen)
            {
                SelectedKeyboardList.Add(currentLetter);
                TextBoxes[letterCounter].Text = currentLetter.Content.ToString();
                currentWord += currentLetter.Content.ToString().ToLower();
                selectedTextBoxes.Add(TextBoxes[letterCounter]);
                letterCounter++;
            }
            
        }

        private void Enter_(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (currentWord == "xy")
            {
                cheat.Content = mainWindow.selectedWord;
            }
            if (currentWord== "xx")
            {
                MessageBox.Show($"You win");
                Screen.Visibility = Visibility.Collapsed;
                Finish();
            }
            if (currentWord.Length == mainWindow.WordLen)
            {
                if (mainWindow.ApiSelected == false)
                {
                    if (MainWindow.SelectedLen.Contains(currentWord))
                    {
                        rows++;
                        for (int i = 0; i < selectedTextBoxes.Count; i++)
                        {
                            selectedTextBoxes[i].Background = Brushes.Black;
                        }
                        for (int i = 0; i < currentWord.Length; i++)
                        {
                            selectedTextBoxes[i].Background = Brushes.Black;
                            SelectedKeyboardList[i].Background = Brushes.Black;
                            if (mainWindow.selectedWord.Contains(currentWord[i]))
                            {
                                selectedTextBoxes[i].Background = Brushes.Red;
                                SelectedKeyboardList[i].Background = Brushes.Red;
                                if (currentWord[i] == mainWindow.selectedWord[i])
                                {
                                    selectedTextBoxes[i].Background = Brushes.Green;
                                    SelectedKeyboardList[i].Background = Brushes.Green;
                                }
                            }
                        }
                        if (currentWord == mainWindow.selectedWord)
                        {
                            for (int i = 0; i < selectedTextBoxes.Count; i++)
                            {
                                selectedTextBoxes[i].Background = Brushes.Green;
                            }
                            MessageBox.Show($"You win");
                            Screen.Visibility = Visibility.Collapsed;
                            Finish();
                        }
                        else
                        {
                            for (int i = letterCounter; i < letterCounter + mainWindow.WordLen; i++)
                            {
                                if (i < TextBoxes.Count)
                                {
                                    TextBoxes[i].Background = Brushes.Gray;
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Word does not exist");
                        letterCounter = rows * mainWindow.WordLen;
                        for (int i = 0; i < selectedTextBoxes.Count; i++)
                        {
                            selectedTextBoxes[i].Text = "";
                        }
                    }
                }
                else
                {
                    rows++;
                    for (int i = 0; i < selectedTextBoxes.Count; i++)
                    {
                        selectedTextBoxes[i].Background = Brushes.Black;
                    }
                    for (int i = 0; i < currentWord.Length; i++)
                    {
                        selectedTextBoxes[i].Background = Brushes.Black;
                        SelectedKeyboardList[i].Background = Brushes.Black;
                        if (mainWindow.selectedWord.Contains(currentWord[i]))
                        {
                            selectedTextBoxes[i].Background = Brushes.Red;
                            SelectedKeyboardList[i].Background = Brushes.Red;
                            if (currentWord[i] == mainWindow.selectedWord[i])
                            {
                                selectedTextBoxes[i].Background = Brushes.Green;
                                SelectedKeyboardList[i].Background = Brushes.Green;
                            }
                        }
                    }
                    if (currentWord == mainWindow.selectedWord)
                    {
                        for (int i = 0; i < selectedTextBoxes.Count; i++)
                        {
                            selectedTextBoxes[i].Background = Brushes.Green;
                        }
                        MessageBox.Show($"You win");
                        Finish();
                    }
                    else
                    {
                        for (int i = letterCounter; i < letterCounter + mainWindow.WordLen; i++)
                        {
                            if (i < TextBoxes.Count)
                            {
                                TextBoxes[i].Background = Brushes.Gray;
                            }
                        }
                    }
                }
                currentWord = "";
                selectedTextBoxes.Clear();
                SelectedKeyboardList.Clear();
            }
            if (TextBoxes.Count() == letterCounter)
            {
                MessageBox.Show($"You lose\n\nThe correct word was: {mainWindow.selectedWord}");
                Finish();
            }
        }
        private void Delete_(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (letterCounter > 0 && TextBoxes[letterCounter - 1].Background == Brushes.Gray && currentWord.Length > 0)
            {
                TextBoxes[letterCounter - 1].Text = "";
                currentWord = currentWord.Remove(currentWord.Length - 1, 1);
                if (letterCounter >= rows * mainWindow.WordLen)
                {
                    letterCounter--;
                }
            }
        }

        private void Finish()
        {
            Screen.Visibility = Visibility.Collapsed;
        }


    }
}
