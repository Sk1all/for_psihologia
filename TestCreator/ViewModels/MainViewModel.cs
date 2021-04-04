using System.Collections.ObjectModel;

namespace TestCreator.ViewModels
{
    class MainViewModel : NotificationObject
    {
        private ObservableCollection<QuestionListViewModel> _questionListFrame;
        public ObservableCollection<QuestionListViewModel> QuestionListFrame
        {
            get { return _questionListFrame; }
            set { SetProperty(ref _questionListFrame, value, () => QuestionListFrame); }
        }

        private ObservableCollection<TestsListViewModel> _testsListFrame;
        public ObservableCollection<TestsListViewModel> TestsListFrame
        {
            get { return _testsListFrame; }
            set { SetProperty(ref _testsListFrame, value, () => TestsListFrame); }
        }
    }
}
