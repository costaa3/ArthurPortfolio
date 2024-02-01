using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MTApp
{
    internal class Program
    {
        private static int amount = 0;
        static void Main(string[] args)
        {
            practiceSomething();
            Console.ReadLine();
        }

        private static void UsingTasksCancelatiomToken()
        {

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task taskToPerform = Task.Run(() =>
            {
                showSomething();

                while (true)
                {
                    var (a, k) = (3, 5);

                    if (token.IsCancellationRequested) return;
                }

            }, token);

            Thread.Sleep(10000);
            cts.Cancel();


        }

        private static void practiceSomething()
        {
            var myCompletion = new TaskCompletionSource<bool>();

            var myThread = new Thread(() =>
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                while (sw.ElapsedMilliseconds < 30000)
                {
                    Console.Write(".");
                    Console.WriteLine(sw.ElapsedMilliseconds);

                    Thread.Sleep(1000);
                }
                myCompletion.SetResult(true);
            });


            myThread.Start();
            Console.WriteLine("Obtaining Result");
            var res = myCompletion.Task.Result;
            //myCompletion.Task.Wait
            Console.WriteLine("Obtained Result");

            Console.WriteLine("Is going to block the current method now");
            myThread.Join();
            Console.WriteLine("Finished waiting");
        }

        private static void UsingTaskTradSource()
        {
            var completetionSource = new TaskCompletionSource<bool>();



        }

        private static void UsingTasksWait()
        {
            CancellationTokenSource Cts = new CancellationTokenSource();
            CancellationTokenSource Cts2 = new CancellationTokenSource();

            CancellationToken token = Cts.Token;
            CancellationToken token2 = Cts2.Token;



            var exec = new Task<bool>(() =>
            {

                try
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();
                    while (true)
                    {
                        if (token.IsCancellationRequested) break;
                        if (sw.ElapsedMilliseconds > 30000) return false;
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Exception triggered");
                }

                return true;
            });

            exec.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("The task has finished from the awaiter side");
            });

            exec.Wait();
            var data = exec.Result;
            Thread.Sleep(10000);
            Console.WriteLine("fINISHED");
            //Cts.Cancel();
            //Cts.Dispose();

        }

        private static bool showSomething(IUser user)
        {
            if (user is null) return false;
            //-if (user is ( Name == "Ana",Password=="basd")) CLIENT.Password = null;
            return false;
        }


        protected class Client : IUser
        {
            public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }

        protected class User : IUser
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public User() { }
            public User(string name, string password) { }
        }
        private static void UsingThreads()
        {

            Thread exeq1 = new Thread(() =>
            {
                try
                {
                    Stopwatch t = new Stopwatch();

                    t.Start();

                    while (true)
                    {
                        Console.Write(".");
                        if (t.ElapsedMilliseconds > 10000) break;
                        Thread.Sleep(100);

                    }
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("Thread has stopped");
                    //
                    //throw;
                }


            });

            exeq1.Start();

            if (exeq1.Join(2000))
            {
                Console.WriteLine("thread completed within 20 sec");
            }
            else
            {
                Console.WriteLine("Thread did not complete within 20 sec");
            }

            if (exeq1.IsAlive)
            {
                exeq1.Interrupt();
            }

            Console.WriteLine("Finishe      ");

            Console.ReadLine();
        }

        private static void showSomething(int value = 21, Stopwatch inst = null)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Hello" + value);
            if (inst != null) Console.WriteLine("stop:" + inst.ElapsedMilliseconds);
            Console.WriteLine("------------------------");
        }

        private static void Getu()
        {
            Thread myEx = new Thread(() => { });


        }
    }
}
