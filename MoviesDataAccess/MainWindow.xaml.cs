using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MoviesDataAccess
{
    public partial class MainWindow : Window
    {
        List<Movie> movies = new List<Movie>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateListBinding()
        {
            resultsCountLabel.Content = "Number of Search Results: " + movies.Count.ToString();
            
            moviesFoundListbox.ItemsSource = movies;
            moviesFoundListbox.DisplayMemberPath = "FullInfo";
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchBy field;
            resultsCountLabel.Content = "";

            if (YearRadioButton.IsChecked == true) { field = SearchBy.year; }
            else if (GenreRadioButton.IsChecked == true) { field = SearchBy.genre; }
            else { field = SearchBy.title; }

            DataAccess db = new DataAccess();

            movies = db.GetMovies(SearchTextbox.Text, field);
            UpdateListBinding();
        }
    }
}
