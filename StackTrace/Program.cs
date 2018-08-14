using System;
using System.Reflection;

namespace StackTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Case1();
            //Case2();
            try
            {
                int threhold = 20;
                int result = threhold / 0;
            }
            catch (Exception ex)
            {
                PreserveStackTrace(ex);
                throw;
            }

            Console.ReadLine();
        }

        private static void Case1()
        {
            try
            {
                DeviviByZero();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Throw full exception 
        private static void Case2()
        {
            try
            {
                DeviviByZero();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void DeviviByZero()
        {
            int threhold = 20;
            int result = threhold / 0;
        }

        private static void PreserveStackTrace(Exception ex)
        {
            MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);
            preserveStackTrace.Invoke(ex, null);
        }
    }
}
