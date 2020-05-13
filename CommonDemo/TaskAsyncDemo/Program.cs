using System;
using System.Threading.Tasks;

namespace TaskAsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Task task = Test();
            //不等待
            task.GetAwaiter().OnCompleted(() => {
                Console.WriteLine("Test Completed!");
            });
            //等待 等同于await
            //task.GetAwaiter().GetResult();
            Console.WriteLine("Bye World!");
            Console.ReadLine();
        }

        static async Task Test()
        {
            Console.WriteLine("Begin to test!");
            var i_Result = GetSumAsync();
            Console.WriteLine(await i_Result);
            //var i_Result = await GetSumAsync();
            //var str_Result = await GetStringAsync();
            var str_Result = GetStringAsync();
            Console.WriteLine(await str_Result);
            //Console.WriteLine(i_Result.ToString());
            //Console.WriteLine(str_Result);
          
            Console.WriteLine("End test!");
        }

        static async Task<int> GetSumAsync()
        {
            Console.WriteLine("To get a sum!");
            return await Task.Run(() =>
            {
                int sum = 0;
                for (int i = 0; i < 5100; i++)
                {
                    sum += i;
                }
                Console.WriteLine("End of the loop!");
                return sum;
            });
        }

        static async Task<string> GetStringAsync()
        {
            return await Task.Run(() => {
                Console.WriteLine("To get a string!");
                return "A string for test";
            });
        }
    }
}
