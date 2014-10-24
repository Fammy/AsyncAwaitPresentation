using System;
using System.Threading;

namespace CodeCamp.Async.Example1
{
    public class SyncObject
    {
        public void DoSyncThing()
        {
            DoThing1();
            DoThing2();
            DoThing3();
        }

        private void DoThing1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Sync Thing 1");
        }

        private void DoThing2()
        {
            Thread.Sleep(500);
            Console.WriteLine("Sync Thing 2");
        }

        private void DoThing3()
        {
            Thread.Sleep(250);
            Console.WriteLine("Sync Thing 3");
        }
    }
}
