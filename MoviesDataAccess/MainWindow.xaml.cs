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
        {// UPDATES MOVIESFOUNDLISTBOX WITH SEARCH RESULTS
            resultsCountLabel.Content = "Number of Search Results: " + movies.Count.ToString();
            
            moviesFoundListbox.ItemsSource = movies;
            moviesFoundListbox.DisplayMemberPath = "FullInfo";
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchBy field;
            resultsCountLabel.Content = "";

            // IF '<SELECTION>RADIOBUTTON' IS CHECKED, FIELD EQUALS <SELECTION>, ELSE SEARCHBY TITLE
            field = (YearRadioButton.IsChecked == true) ? SearchBy.year : (GenreRadioButton.IsChecked == true) ? SearchBy.genre : SearchBy.title;

            DataAccess db = new DataAccess();

            movies = db.GetMovies(SearchTextbox.Text, field);
            UpdateListBinding();
        }
    }
}