using TestCreator.Utils;

namespace TestCreator.ViewModels
{
    public class QuestionViewModel : NotificationObject
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value, () => Number); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value, () => Text); }
        }


        private DelegateCommand _DelQuestionSelfCommand;
        public DelegateCommand DelQuestionSelfCommand
        {
            get 
            { 
                return _DelQuestionSelfCommand 
                    ?? (_DelQuestionSelfCommand 
                    = new DelegateCommand(DelQuestionSelfExecute)); 
            }
        }

        private void DelQuestionSelfExecute()
        {
            QuestionListViewModel.DelQuestion(this);
        }
    }
}
