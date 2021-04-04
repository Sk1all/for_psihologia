using System.Collections.ObjectModel;

namespace TestCreator.ViewModels
{
    public class QuestionListViewModel : NotificationObject
    {
        public QuestionListViewModel()
        {
            _instance = this;
            QuestionVMs = new ObservableCollection<QuestionViewModel>();
        }


        private ObservableCollection<QuestionViewModel> _questionVMs;

        public ObservableCollection<QuestionViewModel> QuestionVMs
        {
            get { return _questionVMs; }
            set { SetProperty(ref _questionVMs, value, () => QuestionVMs); }
        }


        private DelegateCommand _AddQuestionCommand;
        public DelegateCommand AddQuestionCommand
        {
            get { return _AddQuestionCommand ?? (_AddQuestionCommand = new DelegateCommand(AddQuestionExecute)); }
        }

        private void AddQuestionExecute()
        {
            QuestionVMs.Add(new QuestionViewModel { Number = QuestionVMs.Count + 1 });
        }


        private static QuestionListViewModel _instance;

        public static void DelQuestion(QuestionViewModel question)
        {
            if (_instance == null) return;

            if (_instance.QuestionVMs.Contains(question))
            {
                _instance.QuestionVMs.Remove(question);
            }

            _instance._recalculateNumbers();
        }

        private void _recalculateNumbers()
        {
            for (int number = 1; number <= QuestionVMs.Count; number++)
            {
                QuestionVMs[number - 1].Number = number;
            }
        }
    }
}
