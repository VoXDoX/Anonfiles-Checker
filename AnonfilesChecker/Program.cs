using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AnonfilesChecker
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program.title();

            Logger.Printf("Введите кол-во генерации ссылок:", Logger.Type.INFO);
            string count = Console.ReadLine();

            total = 0;
            int urls = 0;
            Int32.TryParse(count, out urls);

            WebClient client = new WebClient();
            if (urls == 0)
            {
                while (true)
                {
                    string getRandom = RandomString(10);
                    try
                    {

                        string checkValid = client.DownloadString("https://anonfiles.com/" + getRandom);
                        if (!checkValid.Contains("The file you are looking for does not exist!"))
                        {
                            Logger.Printf("[VALID] https://anonfiles.com/" + getRandom, Logger.Type.SUCCESS);
                            File.AppendAllText("valid.txt", "https://anonfiles.com/" + getRandom + Environment.NewLine);
                        }
                        else
                        {
                            Logger.Printf("[INVALID] https://anonfiles.com/" + getRandom, Logger.Type.ERROR);
                        }
                    }
                    catch
                    {
                        Logger.Printf("[INVALID] https://anonfiles.com/" + getRandom, Logger.Type.ERROR);
                    }
                    total++;
                    Console.Title = "AnonFiles Checker by VoX DoX | @End_Soft >> " + total;
                }
            }
            else
            {
                while (total < urls)
                {
                    string getRandom = RandomString(10);

                    try
                    {
                        string checkValid = client.DownloadString("https://anonfiles.com/" + getRandom);
                        if (!checkValid.Contains("The file you are looking for does not exist!"))
                        {
                            Logger.Printf("[VALID] https://anonfiles.com/" + getRandom, Logger.Type.SUCCESS);

                            File.AppendAllText("valid.txt", "https://anonfiles.com/" + getRandom + Environment.NewLine);
                        }
                    }
                    catch
                    {
                        Logger.Printf("[INVALID] https://anonfiles.com/" + getRandom, Logger.Type.ERROR);
                    }
                    total++;
                    Console.Title = "AnonFiles Checker by VoX DoX | @End_Soft >> " + total;
                }
            }
            Console.ReadLine();
        }

        public static void title()
        {
            Console.Title = "AnonFiles Generator and Checker by VoX DoX | @End_Soft";
            Console.WriteLine(" ╔═══╗────────╔═╗╔╗───────╔═══╦╗───────╔╗			");
            Console.WriteLine(" ║╔═╗║────────║╔╝║║───────║╔═╗║║───────║║	        ");
            Console.WriteLine(" ║║─║╠═╗╔══╦═╦╝╚╦╣║╔══╦══╗║║─╚╣╚═╦══╦══╣║╔╦══╦═╗		");
            Console.WriteLine(" ║╚═╝║╔╗╣╔╗║╔╬╗╔╬╣║║║═╣══╣║║─╔╣╔╗║║═╣╔═╣╚╝╣║═╣╔╝		");
            Console.WriteLine(" ║╔═╗║║║║╚╝║║║║║║║╚╣║═╬══║║╚═╝║║║║║═╣╚═╣╔╗╣║═╣║		");
            Console.WriteLine(" ╚╝─╚╩╝╚╩══╩╝╚╩╝╚╩═╩══╩══╝╚═══╩╝╚╩══╩══╩╝╚╩══╩╝		");
            Console.WriteLine("                             by VoX DoX | https://t.me/End_Soft");
            Console.WriteLine("");

            if (!File.Exists("valid.txt"))
            {
                File.Create("valid.txt");
            }

        }

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static Random random = new Random();

        public static int total;
        public static int valid;
        public static int invalid;
    }
}