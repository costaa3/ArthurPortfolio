using Seeing_moving_objects.View.ViewModel;
using Seeing_moving_objects.ViewModel.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Seeing_moving_objects.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {

        private Task task1;
        private Task task2;
        private Task task3;
        private Task task4;



        public MainViewModel()
        {
            //AssignRandom();
            cancellationTokenSource = new CancellationTokenSource();
            tkn = cancellationTokenSource.Token;
            Stop = new RelayCommand(CancelOperation);
            Start = new RelayCommand(AssignRandom);
        }
        public ICommand Stop { get; }
        public ICommand Start { get; }

        private void CancelOperation(object o)
        {
            if (!cancellationTokenSource.IsCancellationRequested)
            {


                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();
            }
        }
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken tkn;

        private double scroll1Step;
        private double scroll2Step;
        private double scroll3Step;
        private double scroll4Step;

        public double Scroll1Step
        {
            get { return scroll1Step; }
            set
            {
                scroll1Step = value;
                OnNotifyPropertyChanged();
            }
        }
        public double Scroll2Step
        {
            get { return scroll2Step; }
            set
            {
                scroll2Step = value;
                OnNotifyPropertyChanged();

            }
        }
        public double Scroll3Step
        {
            get { return scroll3Step; }
            set
            {
                scroll3Step = value;
                OnNotifyPropertyChanged();

            }
        }
        public double Scroll4Step
        {
            get { return scroll4Step; }
            set
            {
                scroll4Step = value;
                OnNotifyPropertyChanged();

            }
        }


        private void GetRandomValueAppended(Action<double> func, CancellationToken tkn)
        {

            Random rndGen = new Random();
            while (!tkn.IsCancellationRequested)
            {
                func(rndGen.Next(0, 100));
                Thread.Sleep(500);
            }

        }

        private void AssignRandom(object obj = null)
        {
            if (cancellationTokenSource.IsCancellationRequested)
            {

                cancellationTokenSource = new CancellationTokenSource();
                tkn = cancellationTokenSource.Token;
            }
            if (task1 == null || task1.IsCompleted)
            {
                task1 = Task.Run(() => GetRandomValueAppended((double val) => Scroll1Step = val, tkn));
            }

            if (task2 == null || task2.IsCompleted)
            {
                task2 = Task.Run(() => GetRandomValueAppended((double val) => Scroll2Step = val, tkn));
            }

            if (task3 == null || task3.IsCompleted)
            {
                task3 = Task.Run(() => GetRandomValueAppended((double val) => Scroll3Step = val, tkn));

            }

            if (task4 == null || task4.IsCompleted)
            {
                task4 = Task.Run(() => GetRandomValueAppended((double val) => Scroll4Step = val, tkn));
            }

        }

    }
}
