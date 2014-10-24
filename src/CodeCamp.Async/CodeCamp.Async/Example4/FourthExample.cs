using System;
using System.Threading.Tasks;

namespace CodeCamp.Async.Example4
{
    public static class FourthExample
    {
        public static void Execute()
        {
            HandleExceptionsTheOldWay();
            //HandleExceptionsTheNewWay();
        }

        private static void HandleExceptionsTheOldWay()
        {
            Task task;

            try
            {
                task = Task.Run(() =>
                {
                    Console.WriteLine("Line1");
                    Console.WriteLine("Line2");

                    throw new Exception("I'm bad!");

                    Console.WriteLine("Line3");
                });
            }
            catch (Exception ex)
            {
                // Doesn't catch the exception in the task. D'oh
                Console.WriteLine("Exception: " + ex.Message);
                return;
            }

            task.ContinueWith(t =>
            {
                // Can't trust code after this, as it may require above to have not failed
                if (t.IsFaulted)
                {
                    Console.WriteLine("Quitting early");
                    return;
                }

                Console.WriteLine("Last Line");
            });
        }

        private static async void HandleExceptionsTheNewWay()
        {
            try
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("Line1");
                    Console.WriteLine("Line2");

                    throw new Exception("I'm bad!");

                    Console.WriteLine("Line3");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Quitting early");
                return;
            }

            Console.WriteLine("Last Line");
        }
    }
}
