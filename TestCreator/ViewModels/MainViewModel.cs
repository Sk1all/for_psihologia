using System.Collections.ObjectModel;
using TestCreator.Utils;

namespace TestCreator.ViewModels
{
    public class MainViewModel : NotificationObject
    {
        private static MainViewModel _instance;
        public static MainViewModel Instance { get => _instance; }
        public MainViewModel()
        {
            _instance = this;
        }

        private TestsListViewModel _testsListFrame;
        public TestsListViewModel TestsListFrame
        {
            get { return _testsListFrame; }
            set { SetProperty(ref _testsListFrame, value, () => TestsListFrame); }
        }

        private ObservableCollection<QuestionListViewModel> _questionListFrames;
        public ObservableCollection<QuestionListViewModel> QuestionListFrames
        {
            get { return _questionListFrames; }
            set { SetProperty(ref _questionListFrames, value, () => QuestionListFrames); }
        }

        private QuestionListViewModel _currentQuestionListFrame;
        public QuestionListViewModel CurrentQuestionListFrame
        {
            get { return _currentQuestionListFrame; }
            set 
            {
                QuestionListViewModel.Instance = value;
                SetProperty(ref _currentQuestionListFrame, value, () => CurrentQuestionListFrame); 
            }
        }
    }
}
