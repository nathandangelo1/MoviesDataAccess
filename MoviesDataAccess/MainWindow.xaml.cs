using System.Collections.Generic;
using System.Windows;

namespace MoviesDataAccess
{
    public partial class MainWindow : Window
    {
        List<Movie> movies = new List<Movie>();
        public MainWindow()
        {
            InitializeComponent();

            UpdateListBinding();
        }

        private void UpdateListBinding()
        {
            moviesFoundListbox.ItemsSource = movies;
            moviesFoundListbox.DisplayMemberPath = "FullInfo";
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            movies = db.GetMovies(SearchTextbox.Text);
            UpdateListBinding();
        }
    }
}
