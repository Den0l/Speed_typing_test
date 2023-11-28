using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Drawing;
using System.IO;


namespace Speed_typing_test
{
    internal class STTest
    {
        
        static public string text = "Однажды ночью сотрудники Отдела Смерти звонят Матео Торресу и Руфусу Эметерио, чтобы сообщить им плохие новости: сегодня они умрут. Матео и Руфус не знакомы, но оба по разным причинам ищут себе друга, с которым проведут Последний день. К счастью, специально для этого есть приложение Последний друг, которое помогает им встретиться и вместе прожить целую жизнь за один день. Вдохновляющая и душераздирающая, очаровательная и жуткая, эта книга напоминает о том, что нет жизни без смерти, любви без потери и что даже за один день можно изменить свой мир.";
        static public char[] textfortest = text.ToCharArray();
        static public char letters;
        static private ConsoleKeyInfo Tkey;
        static private int size = textfortest.Length;
        static private List<Player> player = new List<Player>();
        static public void Text()
        {
            Console.SetCursorPosition(0,0);
            foreach (char c in textfortest) 
            {
                Console.Write(c);
            } 
        }
        static public void Record()
        {
            string json = File.ReadAllText(@"C:\Users\denol\Desktop\Record.json");
            player = Records.ReadJson(json, player);
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Рекорды:");
            foreach (var p in player)
            {
                Console.WriteLine("Имя:" + p.name + " Сим/минута:" + p.cpm + " Сим/секунда:" + p.cps);
            }
        }

        static public void Test(string name, Thread time) 
        {
            int point = 0;
            int x = 0;
            int y = 0;
            Console.SetCursorPosition(0, 0);
          
                for (int i = 0; i < size; i++)
                {
                    if (!time.IsAlive)
                    {
                        break;
                    }
                    do
                    {

                        if (x != Console.WindowWidth)
                        {

                            Tkey = Console.ReadKey(true);
                            if (Tkey.KeyChar == textfortest[i])
                            {
                                Console.SetCursorPosition(x, y);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(Tkey.KeyChar);
                                break;
                            }
                            else
                            {
                                Console.SetCursorPosition(x, y);
                                Console.ResetColor();
                                Console.Write(textfortest[i]);
                                continue;
                            }
                        }
                        else
                        {
                            y++;
                            x = 0;
                        }
                    } while (Tkey.KeyChar != textfortest[i]);
                    x++;
                    point = i;
                }
                Console.ResetColor();
            
            player.Add(new Player(name, point, point / 60.0));
           
            string json = File.ReadAllText(@"C:\Users\denol\Desktop\Record.json");
            Records.SaveJson(player);
            player = Records.ReadJson(json ,player);
            Record();       
        }

        static public void Timer()
        {
            Console.SetCursorPosition(0, 9);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 60; i++)
            {
                Console.ResetColor();
                Console.SetCursorPosition(0,9);
                Console.Write($"0:{60 - (sw.ElapsedMilliseconds/1000)}");
                Thread.Sleep(1000);
            }
            sw.Stop();
        }

    }
}
