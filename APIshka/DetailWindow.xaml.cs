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
using System.Windows.Shapes;
using static APIshka.MainWindow;

namespace APIshka
{
    /// <summary>
    /// Логика взаимодействия для DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public DetailWindow(NumberFact fact)
        {
            InitializeComponent();
            FactTextBlock.Text = fact.Text;
            NumberTextBlock.Text = $"Number: {fact.Number}";
            TypeTextBlock.Text = $"Type: {fact.Type}";
        }
    }
}
