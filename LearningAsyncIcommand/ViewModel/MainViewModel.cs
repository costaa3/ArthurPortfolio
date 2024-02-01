using LearningAsyncIcommand.ViewModel.Common;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningAsyncIcommand.ViewModel
{
    internal class MainViewModel : BaseViewModel, IDisposable
    {

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        public MainViewModel()
        {
            RunCommand = new AsyncExecutionCommand(SetRandomNumbers);
            StopCommand = new RelayCommand(StopRandomizer);
            InitializeCancelToken();
        }

        private void InitializeCancelToken()
        {
            if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _cancellationTokenSource.Token;
            }

        }

        private int valueToShow;

        public int ValueToShow
        {
            get => valueToShow; set
            {
                valueToShow = value;
                OnPropertyChanged();
            }
        }

        public ICommand RunCommand { get; }
        public ICommand StopCommand { get; }

        async Task SetRandomNumbers()
        {
            try
            {
                Random rnd = new Random();
                while (true)
                {
                    ValueToShow = rnd.Next(0, 100);
                    await Task.Delay(100, _cancellationToken);
                    if (_cancellationToken.IsCancellationRequested) return;
                }
            }
            catch (Exception)
            {

                Debugger.Log(0, "Finished task", "Task has been stoped");
            }

        }
        async void StopRandomizer()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            InitializeCancelToken();
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
        }
    }
}
