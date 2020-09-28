using System;
using System.Threading.Tasks;
using AES_192_CBC;

namespace aes192cbc
{
    class Program
    {
        private static void Main(string[] args)
        {
            string arg0;
            try
            {
                arg0 = args[0];
            }
            catch
            {
                arg0 = "error";
            }

            var str = args.Length <= 1 ? "Error" : args[1];
            var key = args.Length <= 2 ? "Error" : args[2];

            switch (arg0.ToLower())
            {
                case "decrypt":
                    if (str == "Error" || key == "Error")
                    {
                        Console.WriteLine("You need help? type 'aes256cbc.exe help'" + Environment.NewLine);
                        return;
                    }
                    _ = Decrypt(str, key);
                    break;

                case "encrypt":
                    if (str == "Error" || key == "Error")
                    {
                        Console.WriteLine("You need help? type 'aes256cbc.exe help'" + Environment.NewLine);
                        return;
                    }
                    _ = Encrypt(str, key);
                    break;

                case "help":
                    Help();
                    break;

                default:
                    Console.Write("You need help? type 'aes256cbc.exe help'");
                    break;
            }
            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }

        private static void Help()
        {
            Console.WriteLine("AES-256-CBC Encrypt - Decrypt" + Environment.NewLine);
            Console.WriteLine("Encrypt string:");
            Console.WriteLine("aes256cbc.exe [encrypt] [string*] [iv]" + Environment.NewLine);
            Console.WriteLine("Decrypt string:");
            Console.WriteLine("aes256cbc.exe [decrypt] [string] [iv]" + Environment.NewLine);
            Console.WriteLine("* If you want to encrypt a string that contains a white spaces, enclose the string in quotation marks.");
        }

        private static async Task Decrypt(string str, string key)
        {
            var aes = new AES(key);
            await Task.Run(() => Console.WriteLine(aes.Decrypt(str)));
        }

        private static async Task Encrypt(string str, string key)
        {
            var aes = new AES(key);
            await Task.Run(() => Console.WriteLine(aes.Encrypt(str)));
        }
    }
}
