using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevTools.StepManager
{
    public static class StepManager
    {
        /// <summary>
        /// Run: 應用程式框架 (非同步)
        /// </summary>
        public static async Task RunAsync(Func<Task> func)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            DateTime endTime = DateTime.Now;

            ShowRunTime(startTime, endTime);
            ShowCloseMessage();
        }

        /// <summary>
        /// Step: 不傳入 param 和不傳出 result (非同步)
        /// </summary>
        public static async Task StepAsync(string desc, Func<Task> step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{desc} start");

            await step();

            Console.WriteLine($"{desc} end");
            Console.WriteLine("---------------------------------------");
        }

        /// <summary>
        /// Step: 傳入 param 和不傳出 result (非同步)
        /// </summary>
        public static async Task StepAsync<TParam>(string desc, TParam param, Func<TParam, Task> step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{desc} start");

            await step(param);

            Console.WriteLine($"{desc} end");
            Console.WriteLine("---------------------------------------");
        }

        /// <summary>
        /// Step: 不傳入 param 和傳出 result (非同步)
        /// </summary>
        public static async Task<TResult> StepAsync<TResult>(string desc, Func<Task<TResult>> step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{desc} start");

            TResult result = await step();

            Console.WriteLine($"{desc} end");
            Console.WriteLine("---------------------------------------");

            return result;
        }

        /// <summary>
        /// Step: 傳入 param 和傳出 result (非同步)
        /// </summary>
        public static async Task<TResult> StepAsync<TParam, TResult>(string desc, TParam param, Func<TParam, Task<TResult>> step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{desc} start");

            TResult result = await step(param);

            Console.WriteLine($"{desc} end");
            Console.WriteLine("---------------------------------------");

            return result;
        }

        /// <summary>
        /// Run: 應用程式框架 (同步)
        /// </summary>
        public static void Run(Action func)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                func();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            DateTime endTime = DateTime.Now;

            ShowRunTime(startTime, endTime);
            ShowCloseMessage();
        }

        /// <summary>
        /// Step: 不傳入 param 和不傳出 result (同步)
        /// </summary>
        public static void Step(string desc, Action step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(desc + " " + "start");

            step();

            Console.WriteLine(desc + " " + "end");
        }

        /// <summary>
        /// Step: 傳入 param 和不傳出 result (同步)
        /// </summary>
        public static void Step<TParam>(string desc, TParam param, Action<TParam> step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(desc + " " + "start");

            step(param);

            Console.WriteLine(desc + " " + "end");
        }

        /// <summary>
        /// Step: 不傳入 param 和傳出 result (同步)
        /// </summary>
        public static TResult Step<TResult>(string desc, Func<TResult> step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(desc + " " + "start");

            var reuslt = step();

            Console.WriteLine(desc + " " + "end");

            return reuslt;
        }

        /// <summary>
        /// Step: 傳入 param 和傳出 result (同步)
        /// </summary>
        public static TResult Step<TParam, TResult>(string desc, TParam param, Func<TParam, TResult> step)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(desc + " " + "start");

            TResult result = step(param);

            Console.WriteLine(desc + " " + "end");
            return result;
        }

        /// <summary>
        /// 顯示開始和結束的時間
        /// </summary>
        private static void ShowRunTime(DateTime startTime, DateTime? endTime = null)
        {
            endTime ??= DateTime.Now;

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("startTime: " + startTime.ToString("yyyy/MM/dd HH:mm:ss"));
            Console.WriteLine("endTime: " + endTime.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        /// <summary>
        /// 按下 X 才會離開視窗
        /// </summary>
        private static void ShowCloseMessage()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Press 'X' to exit.");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.X)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 顯示錯誤資訊
        /// </summary>
        private static void ShowException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}
