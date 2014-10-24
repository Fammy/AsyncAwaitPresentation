
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Async.Example2
{
    public static class SecondExample
    {
        public static void Execute()
        {
            AsyncTheOldWayWrong();
            //AsyncTheOldWayCorrect();
            //AsyncTheEasyWay();
            //AsyncTheOldWayComplex();
            //AsyncTheEasyWayComplex();
        }

        private static void AsyncTheOldWayWrong()
        {
            Console.WriteLine("1. Let's do math:");

            var task = DoMath();  // Line 2

            Console.WriteLine("3. The answer is:");
            Console.WriteLine("4. " + task.Result);
        }

        private static Task<int> DoMath()
        {
            return Task.Factory.StartNew(() => // Task.Run() is the .NET 4.5 way
            {
                Console.WriteLine("2. Question: 2 + 2");

                Thread.Sleep(500);

                return 2 + 2;
            });
        }

        private static void AsyncTheOldWayCorrect()
        {
            Console.WriteLine("1. Let's do math:");

            var task = DoMath();

            Task.WaitAny(task);

            Console.WriteLine("3. The answer is:");
            Console.WriteLine("4. " + task.Result);
        }

        private static async void AsyncTheEasyWay()
        {
            Console.WriteLine("1. Let's do math:");

            var task = DoMath();

            Console.WriteLine("3. The answer is:");
            Console.WriteLine("4. " + await task);
        }

        private static void AsyncTheOldWayComplex()
        {
            var task1 = DoTask1();

            var task2 = task1.ContinueWith(t => DoTask2());

            Task.WaitAll(task2);

            DoTask3();
        }

        private static async void AsyncTheEasyWayComplex()
        {
            await DoTask1();
            await DoTask2();
            DoTask3();
        }

        private static Task DoTask1()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 1");
            });
        }

        private static Task DoTask2()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 2");
            });
        }

        private static void DoTask3()
        {
            Console.WriteLine("Task 3");
        }
    }
}
