using System;
using System.Threading.Channels;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args is null)
                {
                    throw new ArgumentNullException($"{nameof(args)}", "nameof(args) is null");
                }
                foreach (var t in args)
                {
                    Console.WriteLine(t[0]);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}