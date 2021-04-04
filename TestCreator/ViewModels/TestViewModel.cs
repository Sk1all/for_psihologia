using TestCreator.Utils;

namespace TestCreator.ViewModels
{
    public class TestViewModel : NotificationObject
    {
        private string _testName;
        public string TestName
        {
            get { return _testName; }
            set { SetProperty(ref _testName, value, () => TestName); }
        }
    }
}
