using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace quiz_rozwiazanie
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>


    public class Pytanie
    {
        public string pytanie { get; set; }
        public string[] odpowiedzi = new string[4];
        public bool[] poprawne = new bool[4];

        public Pytanie(string pytanie, string[] odpowiedzi, bool[] poprawne)
        {
            this.pytanie = pytanie;
            this.odpowiedzi = odpowiedzi;
            this.poprawne = poprawne;
        }

        public Pytanie(Pytanie p)
        {
            pytanie = p.pytanie;
            odpowiedzi = p.odpowiedzi;
            poprawne = p.poprawne;
        }
        public override string ToString()
        {
            return pytanie;
        }
    }


    public partial class MainWindow : Window
    {
        
        int wynik=0;
 
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool Visible { get; set; }

        List<Pytanie> pytania = new List<Pytanie>();
        DispatcherTimer dt = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {          
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
        }
        private int inc = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            inc++;
            timerLabel.Content = inc.ToString();
        }
        private void potwierdzClick(object sender, RoutedEventArgs e)
        {
            if (checkbox1.IsChecked == false && checkbox2.IsChecked == false && checkbox3.IsChecked == false && checkbox4.IsChecked == false)
            {
                System.Windows.MessageBox.Show("Zaznacz najpierw odpowiedź");
            }
            else if(listbox.SelectedIndex > -1)
            {
                try
                {
                    
                    string[] odpowiedzi = new string[4] { odpbox1.Text, odpbox2.Text, odpbox3.Text, odpbox4.Text };
                    bool[] poprawne = new bool[4] { (bool)checkbox1.IsChecked, (bool)checkbox2.IsChecked, (bool)checkbox3.IsChecked, (bool)checkbox4.IsChecked };
                    Pytanie p = new Pytanie(pytaniebox.Text, odpowiedzi, poprawne);
                    

                    for (int n = listbox.Items.Count - 1; n >= 0; --n)
                    {
                        string removelistitem = p.pytanie;
                        if (listbox.Items[n].ToString().Contains(removelistitem))
                        {
                            listbox.Items.RemoveAt(n);
                        }
                    }
                    
                    listbox2.Items.Add(p);
                    listbox.SelectedItem = null;
                    listbox2.SelectedItem = null;
                    pytaniebox.Text = "";
                    odpbox1.Text = "";
                    odpbox2.Text = "";
                    odpbox3.Text = "";
                    odpbox4.Text = "";
                    checkbox1.IsChecked = false;
                    checkbox2.IsChecked = false;
                    checkbox3.IsChecked = false;
                    checkbox4.IsChecked = false;
                }
                catch
                {
                    System.Windows.MessageBox.Show("Podano błędne dane");
                }
            }
            else if (listbox2.SelectedIndex > -1)
            {
                try
                {
                    string[] odpowiedzi = new string[4] { odpbox1.Text, odpbox2.Text, odpbox3.Text, odpbox4.Text };
                    bool[] poprawne = new bool[4] { (bool)checkbox1.IsChecked, (bool)checkbox2.IsChecked, (bool)checkbox3.IsChecked, (bool)checkbox4.IsChecked };
                    Pytanie p = new Pytanie(pytaniebox.Text, odpowiedzi, poprawne);



                    for (int n = listbox2.Items.Count - 1; n >= 0; --n)
                    {
                        string removelistitem = p.pytanie;
                        if (listbox2.Items[n].ToString().Contains(removelistitem))
                        {
                            listbox2.Items.RemoveAt(n);
                        }
                    }
                    listbox2.Items.Add(p);

                    listbox.SelectedItem = null;
                    listbox.SelectedItem = null;
                    pytaniebox.Text = "";
                    odpbox1.Text = "";
                    odpbox2.Text = "";
                    odpbox3.Text = "";
                    odpbox4.Text = "";
                    checkbox1.IsChecked = false;
                    checkbox2.IsChecked = false;
                    checkbox3.IsChecked = false;
                    checkbox4.IsChecked = false;
                }
                catch
                {
                    System.Windows.MessageBox.Show("Podano błędne dane");
                }
            }
        }

        private void listboxChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox.SelectedIndex != -1)
            {
                Pytanie p = listbox.SelectedItem as Pytanie;
                pytaniebox.Text = p.pytanie;
                odpbox1.Text = p.odpowiedzi[0];
                odpbox2.Text = p.odpowiedzi[1];
                odpbox3.Text = p.odpowiedzi[2];
                odpbox4.Text = p.odpowiedzi[3];
                checkbox1.IsChecked = false;
                checkbox2.IsChecked = false;
                checkbox3.IsChecked = false;
                checkbox4.IsChecked = false;
            }
        }

        private void listbox2Changed(object sender, SelectionChangedEventArgs e)
        {
            if (listbox2.SelectedIndex != -1)
            {
                Pytanie p = listbox2.SelectedItem as Pytanie;
                pytaniebox.Text = p.pytanie;
                odpbox1.Text = p.odpowiedzi[0];
                odpbox2.Text = p.odpowiedzi[1];
                odpbox3.Text = p.odpowiedzi[2];
                odpbox4.Text = p.odpowiedzi[3];
                checkbox1.IsChecked = p.poprawne[0];
                checkbox2.IsChecked = p.poprawne[1];
                checkbox3.IsChecked = p.poprawne[2];
                checkbox4.IsChecked = p.poprawne[3];
                
                //listbox2.SelectedItem = null;
            }
        }

        private void listbox3Changed(object sender, SelectionChangedEventArgs e)
        {
            if (listbox2.SelectedIndex != -1)
            {
                //Pytanie p2 in pytania
                Pytanie p = listbox3.SelectedItem as Pytanie;
                foreach(Pytanie p2 in pytania)
                {
                    if (p.pytanie == p2.pytanie)
                    {
                        pytaniebox.Text = p.pytanie;
                        odpbox1.Text = p.odpowiedzi[0];
                        odpbox2.Text = p.odpowiedzi[1];
                        odpbox3.Text = p.odpowiedzi[2];
                        odpbox4.Text = p.odpowiedzi[3];
                        checkbox1.IsChecked = p2.poprawne[0];
                        checkbox2.IsChecked = p2.poprawne[1];
                        checkbox3.IsChecked = p2.poprawne[2];
                        checkbox4.IsChecked = p2.poprawne[3];
                        //listbox3.SelectedItem = null;
                    }
                }
                
            }
        }

        public void wczytajClick(object sender, RoutedEventArgs e) {
            rozpocznij.IsEnabled = true;
            Pytanie p1;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    listbox.Items.Clear();
                    while (!sr.EndOfStream)
                    {
                        p1 = new Pytanie(sr.ReadLine(), new string[4] { sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine() }, 
                            new bool[4] { Convert.ToBoolean(sr.ReadLine()), Convert.ToBoolean(sr.ReadLine()), Convert.ToBoolean(sr.ReadLine()), 
                                Convert.ToBoolean(sr.ReadLine()) });
                        listbox.Items.Add(p1);
                        pytania.Add(p1);
                    }
                }
                //System.Windows.MessageBox.Show(pytania.ToString());
                System.Windows.MessageBox.Show("Wczytano pomyślnie");
            }

        }

        private void rozpocznijClick(object sender, RoutedEventArgs e) {
            rozpocznij.IsEnabled = false;
            wczytaj.IsEnabled = false;
            zakoncz.IsEnabled = true;
            potwierdz.IsEnabled = true;
            checkbox1.IsEnabled = true;
            checkbox2.IsEnabled = true;
            checkbox3.IsEnabled = true;
            checkbox4.IsEnabled = true;
            listbox.IsEnabled = true;
            listbox2.IsEnabled = true;
            dt.Start();
        }



        private void zakonczClick(object sender, RoutedEventArgs e) {
            if (listbox.Items.Count!=0)
            {
                System.Windows.MessageBox.Show("Odpowiedz najpierw na wszystkie pytania!");
            }
            else
            {
                dt.Stop();


                foreach (Pytanie p in listbox2.Items)
                {
                    foreach (Pytanie p2 in pytania)
                    {
                        if (p.pytanie == p2.pytanie)
                        {
                            if (p.poprawne[0] == p2.poprawne[0] && p.poprawne[1] == p2.poprawne[1] && p.poprawne[2] == p2.poprawne[2] & p.poprawne[3] == p2.poprawne[3])
                            {
                                wynik++;
                            }
                            else
                            {
                                listbox3.Items.Add(p);
                            }
                        }
                    }
                }



                System.Windows.MessageBox.Show("Twój wynik to: " + wynik + " punktów");


                System.Windows.MessageBox.Show("W listboxie 1 możliwy podgląd błędnych odpowiedzi");

                zakoncz.IsEnabled = false;
                potwierdz.IsEnabled = false;
                checkbox1.IsEnabled = false;
                checkbox2.IsEnabled = false;
                checkbox3.IsEnabled = false;
                checkbox4.IsEnabled = false;
                listbox3.IsEnabled = true;
                listbox3.Visibility = Visibility.Collapsed;
                listbox3.Visibility = Visibility.Visible;
            }
        }

        private void wyjscieClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
