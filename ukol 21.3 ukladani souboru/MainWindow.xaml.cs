using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ukol_21._3_ukladani_souboru
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        // Otevření souboru
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog()
            {
                Filter = "txt soubory (*.txt)|*.txt",
                Title = "Otevřít TXT soubor"
            };

            if (OD.ShowDialog() == true)
            {
                path = OD.FileName;
                WriteBTN.IsEnabled = true;
                precist(path);
            }
        }
        //načíst obsah
        private void precist(string path)
        {
            TextVystup.Text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string radek;
                while ((radek = sr.ReadLine()) != null)
                {
                    TextVystup.Text += radek + "\n";
                }
            }
        }
        // Zápis a uložení do souboru
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string vstup = TextVstup.Text;
            if (!string.IsNullOrEmpty(vstup))
            {
                string CasDen = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"{CasDen}: {vstup}");
                }

                TextVstup.Text = "";
                precist(path);
            }
            else
            {
                MessageBox.Show("Nelze zapsat, prazdný text", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
