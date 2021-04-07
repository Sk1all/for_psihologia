using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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
            var viewModel = new MainViewModel
            {
                TestsListFrame = new TestsListViewModel
                {
                    TestVMs = new ObservableCollection<TestViewModel>
                    {
                        new TestViewModel 
                        { 
                            TestName = "Раз",
                            QuestionsList = new QuestionListViewModel
                            {
                                QuestionVMs = new ObservableCollection<QuestionViewModel>
                                {
                                    new QuestionViewModel
                                    {
                                        Number = 1,
                                        Text = "Текст первого вопроса",
                                    },
                                    new QuestionViewModel
                                    {
                                        Number = 2,
                                        Text = "А это текст второго вопроса",
                                    },
                                    new QuestionViewModel
                                    {
                                        Number = 3,
                                        Text = "Последний на сегодня вопрос",
                                    }
                                }
                            }
                        },
                        new TestViewModel 
                        { 
                            TestName = "Два",
                            QuestionsList = new QuestionListViewModel
                            {
                                QuestionVMs = new ObservableCollection<QuestionViewModel>
                                {
                                    new QuestionViewModel
                                    {
                                        Number = 1,
                                        Text = "1ого вопроса",
                                    },
                                    new QuestionViewModel
                                    {
                                        Number = 2,
                                        Text = "2ого вопроса",
                                    }
                                }
                            }
                        },
                    }
                }
            };

            viewModel.TestsListFrame.SelectedTestVM = viewModel.TestsListFrame.TestVMs[0];
            
            view.DataContext = viewModel;
            window.Content = view;
            window.Width = 650;
            window.Height = 400;
            window.MinWidth = 550;
            window.MinHeight = 300;
            window.Title = "TestCreator v0.1-dev";
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }
    }
}
