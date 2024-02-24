using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SyncThreads
{
    
    public class MainViewModel :ObservableObject
    {
        Mutex mtx = new Mutex(false);
        SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
        private static int instnuminstnum = 0;
        private static object obj = new object();
        public MainViewModel()
        {

            //Op1 = new AsyncRelayCommand(op1Cmd);
            //Op2 = new AsyncRelayCommand(op2Cmd);
            //Op3 = new AsyncRelayCommand(op3Cmd);

            Op1 = new RelayCommand(op1CmdSyncop1CmdSync);


            Op2 = new RelayCommand(op1CmdSyncop1CmdSync);
            Op2 = new RelayCommand(op1CmdSyncop1CmdSync);
        }

        private string content;

        public string Content
        {
            get => content; set
            {
                content = value;
                OnPropertyChanged();
            }
        }

        public ICommand Op1 { get; }
        public ICommand Op2 { get; }
        public  ICommand Op3 { get; }



        private async Task sHOWOS(int item) {
            //Monitor.Enter(obj);
            mtx.WaitOne();
            //await Semaphore.WaitAsync();
            try
            {
                var instanceNumber = instnuminstnum++;


                WriteLoggText($"=>>>>>>Starting op {item} isntance {instanceNumber}");
                
                //WriteLoggText("this is op 1");
                await Task.Delay(5000 * item);
                //Thread.Sleep(5000 * item);
                WriteLoggText($"=<<<<<<<<Finished op {item}");
            }
            finally
            {
                //Semaphore.Release();
                mtx.ReleaseMutex();

                //Monitor.Exit(obj);
            }

        }

        private void ShowData(int item)
        {
            var instanceNumber = instnuminstnum++;
            Monitor.Enter(obj);
            SortedList<int, int> keyValuePairs = new SortedList<int, int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //mtx.WaitOne();
            //await Semaphore.WaitAsync();
            Random rnd = new Random();
            while (stopwatch.ElapsedMilliseconds<30000)
            {
                var randValue = rnd.Next(255);
                if (!keyValuePairs.ContainsKey(randValue)) { 
                
                keyValuePairs.Add(randValue, randValue);
                }


                WriteLoggText($"{item}"
                + $"OP||||>|||OP {stopwatch.ElapsedMilliseconds} instance Number{instanceNumber} ");
                Thread.Sleep(1000);

            }
            foreach (var value in keyValuePairs)
            {
                WriteLoggText($"{item}"
               + $"Random value at {value.Key} value is {value.Key}");

            }

            WriteLoggText($"{item}"
              + $"OP||||>|||OP {stopwatch.ElapsedMilliseconds} ");
            //try
            //{

            //    WriteLoggText($"=>>>>>>Starting op {item}");

            //    //WriteLoggText("this is op 1");
            //     Thread.Sleep(5000 * item);
            //    //Thread.Sleep(5000 * item);
            //    WriteLoggText($"=<<<<<<<<Finished op {item}");
            //}
            //finally
            //{
            //    //Semaphore.Release();
            //    mtx.ReleaseMutex();

            Monitor.Exit(obj);
            //}

        }

        private async Task Showdd() { 
        WriteLoggText($" hey there ");
            await Task.Delay(10000);
            WriteLoggText($" finished  hey there ");

        }

        private async Task Showdd1()
        {
            WriteLoggText($" hey there 22222222222");
            await Task.Delay(10000);
            WriteLoggText($" finished  hey there ");

        }

        private async Task op1Cmd()
        {

            await sHOWOS(1);
        }

        private async Task op2Cmd()
        {

            await sHOWOS(2);
        }


        private void op1CmdSyncop1CmdSync()
        {

            Task.Run(()=> ShowData(1)) ;
        }

        private void op2CmdSync()
        {

            Task.Run(() => ShowData(2));
        }

        private async Task op3Cmd()
        {

            await sHOWOS(3);
        }

        private void WriteLoggText(string input)
        {
            Content += input +
                "\n";
        }

    }
}
