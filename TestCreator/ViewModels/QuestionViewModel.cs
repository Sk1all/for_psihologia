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
    }
}
