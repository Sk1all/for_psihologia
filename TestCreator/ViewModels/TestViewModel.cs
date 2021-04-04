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

        //private DelegateCommand _showTestOptionsCommand;
        //public DelegateCommand ShowTestOptionsCommand
        //{
        //    get 
        //    { 
        //        return _showTestOptionsCommand 
        //            ?? (_showTestOptionsCommand 
        //            = new DelegateCommand(ShowTestOptionsExecute)); 
        //    }
        //}

        //private void ShowTestOptionsExecute()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
