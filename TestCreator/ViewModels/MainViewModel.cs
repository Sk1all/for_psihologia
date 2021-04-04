using System.Collections.ObjectModel;

namespace TestCreator.ViewModels
{
    class MainViewModel : NotificationObject
    {
        private ObservableCollection<QuestionListViewModel> _contentFrame;
        public ObservableCollection<QuestionListViewModel> ContentFrame
        {
            get { return _contentFrame; }
            set { SetProperty(ref _contentFrame, value, () => ContentFrame); }
        }
   
    }
}
