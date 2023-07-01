using System.Net.Mail;
using System.Net;
using System.Text;
//using System.Timers;


namespace GmailAutoSentEmail
{
    internal class Program
    {
        private static string TempPwd;

        static void Main(string[] args)
        {
            //System.Timers.Timer timer = new System.Timers.Timer();
            System.Threading.Timer timer = new System.Threading.Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            //TimeSpan interval = TimeSpan.FromMinutes(10);
            TempPwd = args[0];              //應用程式密碼
            Console.ReadKey();

            /*System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 10000;
            timer.Start();
            TempPwd = args[0];              //應用程式密碼
            timer.Elapsed += new ElapsedEventHandler(test);
            Console.ReadKey();*/

        }
        private static void test(object source, EventArgs e)
        {
            // 使用 Google Mail Server 發信
            string GoogleID = "ax6030test@gmail.com"; //Google 發信帳號         
            string ReceiveMail = "ax6030test@gmail.com"; //接收信箱

            string SmtpServer = "smtp.gmail.com";
            int SmtpPort = 587;
            MailMessage mms = new MailMessage();
            mms.From = new MailAddress(GoogleID);  
            mms.Subject = "FirstSend";                // 主旨
            // 內文
            mms.Body = @"                  
┌─╮◆╭═┐╭═┐╭═┐◆╭─┐

│┌╯◆║加║║油║║囉║◆╰┐│

╰╯↘◆└═╯└═╯└═╯◆↙╰╯
";
            mms.IsBodyHtml = true;   // 內文是否為 HTML

            mms.Priority = MailPriority.Normal;             // 優先權
            mms.SubjectEncoding = Encoding.UTF8;
            mms.To.Add(new MailAddress(ReceiveMail));
            using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(GoogleID, TempPwd);      //寄信帳密 
                client.Send(mms);      //寄出信件
                Console.WriteLine("寄出時間" + DateTime.Now);
            }
        }

        private static void TimerCallback(object state)
        {
            // 使用 Google Mail Server 發信
            string GoogleID = "ax6030test@gmail.com"; //Google 發信帳號         
            string ReceiveMail = "ax6030test@gmail.com"; //接收信箱

            string SmtpServer = "smtp.gmail.com";
            int SmtpPort = 587;
            MailMessage mms = new MailMessage();
            mms.From = new MailAddress(GoogleID);
            mms.Subject = "FirstSend";                // 主旨
            // 內文
            mms.Body = @"                  
┌─╮◆╭═┐╭═┐╭═┐◆╭─┐

│┌╯◆║加║║油║║囉║◆╰┐│

╰╯↘◆└═╯└═╯└═╯◆↙╰╯
";
            mms.IsBodyHtml = true;
            mms.SubjectEncoding = Encoding.UTF8;
            mms.To.Add(new MailAddress(ReceiveMail));
            using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(GoogleID, TempPwd);      //寄信帳密 
                client.Send(mms);      //寄出信件
                Console.WriteLine("寄出時間" + DateTime.Now);
            }
        }
    }
}