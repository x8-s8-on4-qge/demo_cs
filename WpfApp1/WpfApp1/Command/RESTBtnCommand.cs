using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using APIClient.Service;
using WpfApp1.ViewModel;

namespace WpfApp1.Command
{
    public class RESTBtnCommand : ICommand
    {
        private APIService apiService;

        private MainViewModel vm { get; set; }

        public RESTBtnCommand(MainViewModel view)
        {
            apiService = new APIService();
            vm = view;

            BindingOperations.EnableCollectionSynchronization(vm.DataItems, new object());
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await Task.Run(() =>
            {
                MainViewModel.Items items = new MainViewModel.Items();
                try
                {
                    string message = apiService.GetHelloWorld();

                    items.recieveTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
                    items.message = message;
                }
                catch (Exception ex)
                {
                    items.errorDetail = ex.Message;
                }
                finally
                {
                    vm.DataItems.Add(items);
                }
            });
        }
    }
}
