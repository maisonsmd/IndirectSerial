using MsHelper.Enums;

using System;
using System.Runtime.InteropServices;

namespace MsHelper.Log {

    internal static class Imports {
        public static IntPtr HWND_BOTTOM = (IntPtr)1;

        // public static IntPtr HWND_NOTOPMOST = (IntPtr)-2;
        public static IntPtr HWND_TOP = (IntPtr)0;

        // public static IntPtr HWND_TOPMOST = (IntPtr)-1;

        public static UInt32 SWP_NOSIZE = 1;
        public static UInt32 SWP_NOZORDER = 4;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, Int32 hWndInsertAfter, Int32 x, Int32 Y, Int32 cx, Int32 cy, UInt32 wFlags);
    }

    public class Logger {
        private static EventType lastEt = EventType.Info;
        private static Boolean initialized = false;

        public static void Init() {
            if (initialized) return;
            initialized = true;

            IntPtr consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);

            //Console.SetWindowSize(60, 29);
            Console.Title = "Logger";
            Logi("Author", "maisonsmd");
        }

        public static void Clear() => Console.Clear();

        public static void Logi(String tag, String text) => Log(tag, text, EventType.Info);

        public static void Loge(String tag, String text) => Log(tag, text, EventType.Error);

        public static void Logw(String tag, String text) => Log(tag, text, EventType.Warning);

        public static void Logd(String tag, String text) => Log(tag, text, EventType.Debug);

        private static void Log(String tag, String text, EventType eventType) {
            Init();
            switch (eventType) {
                case EventType.Error:
                    //Console.Beep();
                    if (lastEt != EventType.Error) {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        lastEt = EventType.Error;
                    }
                    break;

                case EventType.Info:
                    if (lastEt != EventType.Info) {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        lastEt = EventType.Info;
                    }
                    break;

                case EventType.Warning:
                    if (lastEt != EventType.Warning) {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        lastEt = EventType.Warning;
                    }
                    break;

                case EventType.Debug:
                    if (lastEt != EventType.Debug) {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        lastEt = EventType.Debug;
                    }
                    break;
            }
            Console.WriteLine($"[{tag}] {text}");
        }
    }
}