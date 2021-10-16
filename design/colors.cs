using System;
using System.Collections.Generic;

namespace design
{
    class Color
    {
	    public static IDictionary<string, ConsoleColor> color_map = new Dictionary<string, ConsoleColor>(){
            {"blue", ConsoleColor.Blue},
            {"red", ConsoleColor.Red},
            {"green", ConsoleColor.Green},
            {"yellow", ConsoleColor.Yellow},
            {"magenta", ConsoleColor.Magenta},
            {"cyan", ConsoleColor.Cyan},
            {"bordo", ConsoleColor.DarkRed},
            {"white", ConsoleColor.White}
        };

        public static void WriteLine(string input=null)
        {
            string[] f_buffer;
            string[] s_buffer;
            if (!input.Contains("["))
            {
                Console.WriteLine(input);
            }
            f_buffer = input.Split("[");
            for (int i = 0; i < f_buffer.Length; i++)
            {
                if (!f_buffer[i].Contains("]"))
                {
                    Console.Write(f_buffer[i]);
                }
                else
                {
                    s_buffer = f_buffer[i].Split("]");
                    foreach (var kvp in color_map)
                    {
                        if (kvp.Key == s_buffer[0])
                        {
                            Console.ForegroundColor = kvp.Value;
                            Console.Write(s_buffer[1]);
                        }
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine("");
        }

        public static void Write(string input)
        {
            string[] f_buffer;
            string[] s_buffer;
            if (!input.Contains("["))
            {
                Console.WriteLine(input);
            }
            f_buffer = input.Split("[");
            for (int i = 0; i < f_buffer.Length; i++)
            {
                if (!f_buffer[i].Contains("]"))
                {
                    Console.Write(f_buffer[i]);
                }
                else
                {
                    s_buffer = f_buffer[i].Split("]");
                    foreach (var kvp in color_map)
                    {
                        if (kvp.Key == s_buffer[0])
                        {
                            Console.ForegroundColor = kvp.Value;
                            Console.Write(s_buffer[1]);
                        }
                    }
                }
            }
            Console.ResetColor();
        }
    }
}
