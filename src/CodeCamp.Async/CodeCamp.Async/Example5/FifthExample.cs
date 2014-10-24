using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace CodeCamp.Async.Example5
{
    public static class FifthExample
    {
        public static void Execute()
        {
            SetupData();
            var timer = new Timer(5000);
            timer.Elapsed += CheckEmail;
            timer.Start();
        }

        private static async void CheckEmail(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var messages = await CheckEmail();
            if (!messages.Any())
            {
                Console.WriteLine("--No new email--");
                return;
            }

            foreach (var message in messages)
            {
                Console.WriteLine("New email: " + message.Subject);
            }
        }

        private static async Task<List<Email>> CheckEmail()
        {
            var online = await IsOnline();

            if (online)
            {
                var emails = await GetUnreadEmailsForCurrentUser();
                return emails;
            }

            return null;
        }

        private static Task<List<Email>> GetUnreadEmailsForCurrentUser()
        {
            return Task.Run(() =>
            {
                if (!Emails.Any())
                {
                    return new List<Email>();
                }

                var list = new List<Email>();
                list.Add(Emails.Dequeue());
                return list;
            });
        }

        private static Task<bool> IsOnline()
        {
            return Task.Run(() =>
            {
                // pretend it takes a few seconds to check if WiFi or Ethernet is connected.
                return true;
            });
        }

        private static Queue<Email> Emails { get; set; }

        private static void SetupData()
        {
            Emails = new Queue<Email>();
            Emails.Enqueue(new Email {Subject = "Great presentation! "});
            Emails.Enqueue(new Email {Subject = "Up next is RavenDB with Adam"});
            Emails.Enqueue(new Email {Subject = "Re: Async is Rad! "});
            Emails.Enqueue(new Email {Subject = "Fw: FW: FW: fw: Funny cat pics "});
            Emails.Enqueue(new Email { Subject = "Buy a raffle ticket, support the Boys & Girls Clubs of the Big Bend" });
        }
    }

    public class Email
    {
        public string Subject { get; set; }
    }
}
