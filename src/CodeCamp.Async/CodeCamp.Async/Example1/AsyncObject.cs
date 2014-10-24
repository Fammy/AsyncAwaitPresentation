using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Async.Example1
{
    public class AsyncObject
    {
        public void DoAsyncThingSynchronously()
        {
            DoThing1();
            DoThing2();
            DoThing3();
        }

        public async void DoAsyncThingTheRightWay()
        {
            await DoThing1();
            await DoThing2();
            await DoThing3();
        }

        private Task DoThing1()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Async Thing 1");
            });
        }

        private Task DoThing2()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("Async Thing 2");
            });
        }

        private Task DoThing3()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(250);
                Console.WriteLine("Async Thing 3");
            });
        }
    }
}