using System.Collections.ObjectModel;
using TestCreator.Utils;

namespace TestCreator.ViewModels
{
    public class TestsListViewModel : NotificationObject
    {
        public TestsListViewModel()
        {
            _instance = this;
            TestVMs = new ObservableCollection<TestViewModel>();
        }

        private ObservableCollection<TestViewModel> _testVMs;

        public ObservableCollection<TestViewModel> TestVMs
        {
            get { return _testVMs; }
            set { SetProperty(ref _testVMs, value, () => TestVMs); }
        }


        private TestViewModel _selectedTest;

        public TestViewModel SelectedTest
        {
            get { return _selectedTest; }
            set { SetProperty(ref _selectedTest, value, () => SelectedTest); }
        }


        private static TestsListViewModel _instance;

        public TestsListViewModel Instance
        {
            get { return _instance; }
        }


        private DelegateCommand _addNewTestCommand;
        public DelegateCommand AddNewTestCommand
        {
            get { return _addNewTestCommand ?? (_addNewTestCommand = new DelegateCommand(AddNewTestExecute)); }
        }

        private void AddNewTestExecute()
        {
            TestVMs.Add(new TestViewModel { TestName = "Новый тест" });
        }


        private DelegateCommand _delSelectedTestCommand;
        public DelegateCommand DelSelectedTestCommand
        {
            get { return _delSelectedTestCommand ?? (_delSelectedTestCommand = new DelegateCommand(DelSelectedTestExecute)); }
        }

        private void DelSelectedTestExecute()
        {
            while (SelectedTest != null)
            {
                if (TestVMs.Contains(SelectedTest))
                {
                    TestVMs.Remove(SelectedTest);
                }
            }
        }


        private DelegateCommand _showSelectedTestOptionsCommand;
        public DelegateCommand ShowSelectedTestOptionsCommand
        {
            get { return _showSelectedTestOptionsCommand ?? (_showSelectedTestOptionsCommand = new DelegateCommand(ShowSelectedTestOptionsExecute)); }
        }

        private void ShowSelectedTestOptionsExecute()
        {

        }
    }
}
