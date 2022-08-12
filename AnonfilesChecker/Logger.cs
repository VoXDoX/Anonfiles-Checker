﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonfilesChecker
{
    class Logger
    {
        public enum Type
        {
            WARNING = ConsoleColor.DarkYellow,
            SUCCESS = ConsoleColor.DarkGreen,
            ERROR = ConsoleColor.DarkRed,
            INFO = ConsoleColor.DarkBlue
        }

        public static void Printf(string text, Type? type = null)
        {
            if (type != null)
            {
                Console.ForegroundColor = (ConsoleColor)type;
            }
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] " + text);
            Console.ResetColor();
        }
    }
}

