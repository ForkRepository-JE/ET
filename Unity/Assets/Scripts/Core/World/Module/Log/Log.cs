using System;
using System.Diagnostics;

namespace ET
{
    public static class Log
    {
        private const int TraceLevel = 1;
        private const int DebugLevel = 2;
        private const int InfoLevel = 3;
        private const int WarningLevel = 4;
        
        
        [Conditional("DEBUG")]
        public static void Debug(string msg)
        {
            if (Options.Instance.LogLevel > DebugLevel)
            {
                return;
            }
            Logger.Instance.Log.Debug(msg);
        }
        
        [Conditional("DEBUG")]
        public static void Trace(string msg)
        {
            if (Options.Instance.LogLevel > TraceLevel)
            {
                return;
            }
            StackTrace st = new(1, true);
            Logger.Instance.Log.Trace($"{msg}\n{st}");
        }

        public static void Info(string msg)
        {
            if (Options.Instance.LogLevel > InfoLevel)
            {
                return;
            }
            Logger.Instance.Log.Info(msg);
        }

        public static void TraceInfo(string msg)
        {
            if (Options.Instance.LogLevel > InfoLevel)
            {
                return;
            }
            StackTrace st = new(1, true);
            Logger.Instance.Log.Trace($"{msg}\n{st}");
        }

        public static void Warning(string msg)
        {
            if (Options.Instance.LogLevel > WarningLevel)
            {
                return;
            }
            Logger.Instance.Log.Warning(msg);
        }

        public static void Error(string msg)
        {
            StackTrace st = new(1, true);
            Logger.Instance.Log.Error($"{msg}\n{st}");
        }

        public static void Error(Exception e)
        {
            Logger.Instance.Log.Error(e.ToString());
        }
        
        public static void Console(string msg)
        {
            if (Options.Instance.Console == 1)
            {
                System.Console.WriteLine(msg);
            }
            Logger.Instance.Log.Debug(msg);
        }

#if DOTNET
        [Conditional("DEBUG")]
        public static void Trace(ref System.Runtime.CompilerServices.DefaultInterpolatedStringHandler message)
        {
            if (Options.Instance.LogLevel > TraceLevel)
            {
                return;
            }
            Logger.Instance.Log.Trace(ref message);
        }
        [Conditional("DEBUG")]
        public static void Warning(ref System.Runtime.CompilerServices.DefaultInterpolatedStringHandler message)
        {
            if (Options.Instance.LogLevel > WarningLevel)
            {
                return;
            }
            Logger.Instance.Log.Warning(ref message);
        }

        public static void Info(ref System.Runtime.CompilerServices.DefaultInterpolatedStringHandler message)
        {
            if (Options.Instance.LogLevel > InfoLevel)
            {
                return;
            }
            Logger.Instance.Log.Info(ref message);
        }
        [Conditional("DEBUG")]
        public static void Debug(ref System.Runtime.CompilerServices.DefaultInterpolatedStringHandler message)
        {
            if (Options.Instance.LogLevel > DebugLevel)
            {
                return;
            }
            Logger.Instance.Log.Debug(ref message);
        }

        public static void Error(ref System.Runtime.CompilerServices.DefaultInterpolatedStringHandler message)
        {
            Logger.Instance.Log.Error(ref message);
        }
#endif
    }
}
