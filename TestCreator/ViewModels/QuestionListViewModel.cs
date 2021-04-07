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
            set 
            {
                SetProperty(ref _selectedQuestion, value, () => SelectedQuestion);
                _delSelectedQuestionsCommand.RaiseCanExecuteChanged();
            }
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
            if (_isVoid) return;

            QuestionVMs.Add(
                new QuestionViewModel { Number = QuestionVMs.Count + 1 });
        }


        public static QuestionListViewModel Void = new QuestionListViewModel { _isVoid = true };
        private bool _isVoid = false;

        public void DelQuestion(QuestionViewModel question)
        {
            if (_isVoid) return;

            if (QuestionVMs.Contains(question))
            {
                QuestionVMs.Remove(question);
            }

            _recalculateNumbers();
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
                    = new DelegateCommand(DelSelectedQuestionsExecute, CanDelSelectedQuestions)); 
            }
        }

        private void DelSelectedQuestionsExecute()
        {
            if (_isVoid) return;

            if (SelectedQuestion == null) return;

            var questIndex = QuestionVMs.Count - 1;

            while (SelectedQuestion != null)
            {
                if (QuestionVMs.IndexOf(SelectedQuestion) < questIndex)
                {
                    questIndex = QuestionVMs.IndexOf(SelectedQuestion);
                }
                DelQuestion(SelectedQuestion);
            }

            if (QuestionVMs.Count > 0)
            {
                if (questIndex > 0)
                {
                    SelectedQuestion = QuestionVMs[questIndex - 1];
                }
                else
                {
                    SelectedQuestion = QuestionVMs[questIndex];
                }
            }
        }

        private bool CanDelSelectedQuestions()
        {
            if (SelectedQuestion != null) return true;
            else return false;
        }
    }
}
