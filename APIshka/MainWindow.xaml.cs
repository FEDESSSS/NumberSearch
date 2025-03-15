using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace APIshka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<NumberFact> _facts = new List<NumberFact>();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public class NumberFact
        {
            public string Text { get; set; }
            public int Number { get; set; }
            public string Type { get; set; }
        }

        private async void LoadData()
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = 1; i <= 999999 && _facts.Count < 99999; i++) 
                {
                    var response = await client.GetStringAsync($"http://numbersapi.com/{i}/trivia?json");
                    var fact = JsonConvert.DeserializeObject<NumberFact>(response);
                    _facts.Add(fact);
                }
            }
            FactsListView.ItemsSource = _facts;
        }


        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_facts == null || FactsListView == null)
            {
                // Обработайте ситуацию, когда данные или элемент управления не инициализированы
                return;
            }

            var searchText = SearchBox.Text.ToLower();
            var filteredFacts = _facts
                .Where(f => f.Text != null && f.Text.ToLower().Contains(searchText))
                .ToList();

            FactsListView.ItemsSource = filteredFacts;
        }



        private void FactsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (FactsListView.SelectedItem is NumberFact selectedFact)
            {
                DetailWindow detailWindow = new DetailWindow(selectedFact);
                detailWindow.ShowDialog();
            }
        }

    }
}
