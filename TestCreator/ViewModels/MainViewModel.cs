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
    }
}
