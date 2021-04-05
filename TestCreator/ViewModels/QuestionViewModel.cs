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


        private DelegateCommand _EditQuestionKeysCommand;
        public DelegateCommand EditQuestionKeysCommand
        {
            get 
            { 
                return _EditQuestionKeysCommand 
                    ?? (_EditQuestionKeysCommand 
                    = new DelegateCommand(EditQuestionKeysExecute)); 
            }
        }

        private void EditQuestionKeysExecute()
        {
            //TODO - реализовать диалог редактирования ключей для вопроса
        }
    }
}
