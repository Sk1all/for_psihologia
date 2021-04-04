using System.Windows;
using TestCreator.ViewModels;
using TestCreator.Views;

namespace TestCreator
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new Window();
            var view = new MainView();
            var viewModel = new MainViewModel();

            viewModel.ContentFrame = new System.Collections.ObjectModel.ObservableCollection<QuestionListViewModel>
            {
                new QuestionListViewModel
                {
                    QuestionVMs = new System.Collections.ObjectModel.ObservableCollection<QuestionViewModel>
                    {
                        new QuestionViewModel()
                        {
                            Number = 1,
                            Text = "Текст первого вопроса",
                        },
                        new QuestionViewModel()
                        {
                            Number = 2,
                            Text = "А это текст второго вопроса",
                        },
                        new QuestionViewModel()
                        {
                            Number = 3,
                            Text = "Последний на сегодня вопрос",
                        },
                    }
                }
            };

            view.DataContext = viewModel;
            window.Content = view;
            window.Width = 500;
            window.Height = 300;
            window.Title = "TestCreator v0.1-dev";
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }
    }
}
