using System.Collections.ObjectModel;
using TestCreator.Utils;

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

        private TestsListViewModel _testsListFrame;
        public TestsListViewModel TestsListFrame
        {
            get { return _testsListFrame; }
            set { SetProperty(ref _testsListFrame, value, () => TestsListFrame); }
        }
    }
}
