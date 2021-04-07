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


        private TestViewModel _selectedTestVM;

        public TestViewModel SelectedTestVM
        {
            get { return _selectedTestVM; }
            set 
            {
                SetProperty(ref _selectedTestVM, value, () => SelectedTestVM);
            }
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
            TestVMs.Add(new TestViewModel { TestName = "Новый тест", QuestionsList = new QuestionListViewModel() });
            SelectedTestVM = TestVMs[TestVMs.Count - 1];
        }


        private DelegateCommand _delSelectedTestCommand;
        public DelegateCommand DelSelectedTestCommand
        {
            get { return _delSelectedTestCommand ?? (_delSelectedTestCommand = new DelegateCommand(DelSelectedTestExecute)); }
        }

        private void DelSelectedTestExecute()
        {
            if (TestVMs.Contains(SelectedTestVM))
            {
                var testIndex = TestVMs.IndexOf(SelectedTestVM);
                TestVMs.Remove(SelectedTestVM);

                if (testIndex > 0)
                {
                    SelectedTestVM = TestVMs[testIndex - 1];
                }
                else if (TestVMs.Count == 1)
                {
                    SelectedTestVM = TestVMs[0];
                }
                else
                {
                    SelectedTestVM = null;
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
