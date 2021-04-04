using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestCreator.Utils;

namespace TestCreator.ViewModels
{
    public class QuestionListViewModel : NotificationObject
    {
        public QuestionListViewModel()
        {
            QuestionVMs = new ObservableCollection<QuestionViewModel>();
        }


        private ObservableCollection<QuestionViewModel> _questionVMs;

        public ObservableCollection<QuestionViewModel> QuestionVMs
        {
            get { return _questionVMs; }
            set { SetProperty(ref _questionVMs, value, () => QuestionVMs); }
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
            get 
            { 
                return _AddQuestionCommand 
                    ?? (_AddQuestionCommand 
                    = new DelegateCommand(AddQuestionExecute)); 
            }
        }

        private void AddQuestionExecute()
        {
            if (Instance._isVoid) return;

            QuestionVMs.Add(
                new QuestionViewModel { Number = QuestionVMs.Count + 1 });
        }


        public static QuestionListViewModel Void = new QuestionListViewModel { _isVoid = true };
        private bool _isVoid = false;

        private static QuestionListViewModel _instance;

        public static QuestionListViewModel Instance
        {
            get { return _instance; } set { _instance = value; }
        }

        public static void DelQuestion(QuestionViewModel question)
        {
            if (Instance._isVoid) return;

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
            get 
            { 
                return _delSelectedQuestionsCommand 
                    ?? (_delSelectedQuestionsCommand 
                    = new DelegateCommand(DelSelectedQuestionsExecute)); 
            }
        }

        private void DelSelectedQuestionsExecute()
        {
            if (Instance._isVoid) return;

            while (SelectedQuestion != null)
            {
                DelQuestion(SelectedQuestion);
            }
        }
    }
}
