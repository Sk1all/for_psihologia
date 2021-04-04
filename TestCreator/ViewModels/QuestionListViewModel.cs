using System.Collections.Generic;
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


        private ObservableCollection<object> _selectedQuestions;

        public ObservableCollection<object> SelectedQuestions
        {
            get { return _selectedQuestions; }
            set { SetProperty(ref _selectedQuestions, value, () => SelectedQuestions); }
        }

        private QuestionViewModel _selectedQuestion;

        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set { SetProperty(ref _selectedQuestion, value, () => SelectedQuestion); }
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

        public static QuestionListViewModel Instance
        {
            get { return _instance; }
        }

        public static void DelQuestion(QuestionViewModel question)
        {
            if (Instance.QuestionVMs.Contains(question))
            {
                Instance.QuestionVMs.Remove(question);
            }

            Instance._recalculateNumbers();
        }

        private void _recalculateNumbers()
        {
            for (int number = 1; number <= QuestionVMs.Count; number++)
            {
                QuestionVMs[number - 1].Number = number;
            }
        }


        private DelegateCommand _delSelectedQuestionsCommand;
        public DelegateCommand DelSelectedQuestionsCommand
        {
            get { return _delSelectedQuestionsCommand ?? (_delSelectedQuestionsCommand = new DelegateCommand(DelSelectedQuestionsExecute)); }
        }

        private void DelSelectedQuestionsExecute()
        {
            while (SelectedQuestion != null)
            {
                DelQuestion(SelectedQuestion);
            }
        }
    }
}
