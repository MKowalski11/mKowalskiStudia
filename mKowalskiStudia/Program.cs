using System;

namespace mKowalskiStudia
{
    class Program
    {
        static void Main(string[] args)
        {

            // v Sprawdzanie zgodności argumentów wejściowych v

            Console.Write("\n");
            if (args.Length != 5)
            {
                Console.WriteLine("Nieprawidlowa ilosc argumentow.");
                return;
            }
            if (double.TryParse(args[1], out double X) != true)
            {
                Console.WriteLine("Nieprawidlowy parametr "+args[1]);
                return;
            }
            if (double.TryParse(args[2],out double x_min) != true)
            {
                Console.WriteLine("Nieprawidlowy parametr " + args[2]);
                return;
            }
            if (double.TryParse(args[3],out double x_max) != true)
            {
                Console.WriteLine("Nieprawidlowy parametr " + args[3]);
                return;
            }
            if (int.TryParse(args[4],out int n) != true)
            {
                Console.WriteLine("Nieprawidlowy parametr " + args[4]);
                return;
            }

            // v analiza formuły v
            string InfixTokens;
            //if ("" + args[0][0] + args[0][1] + args[0][2] == "abs") Console.WriteLine("true");

            InfixTokens = RPN.InfixTokens(args[0]);
            
            if (InfixTokens[0] == 'E' && InfixTokens[1] == 'r' && InfixTokens[2] == 'r') { Console.WriteLine(InfixTokens);return; }
            Console.WriteLine(InfixTokens);
            string[] InfixTokensTab = new string[RPN.InfixTokensCount(InfixTokens)];
            InfixTokensTab = RPN.SplitInfixTokens(InfixTokens,RPN.InfixTokensCount(InfixTokens));
            for (int i=0; i < InfixTokensTab.Length; i++)
            {
                Console.WriteLine(InfixTokensTab[i]);
            }
            //Console.WriteLine("Hello World!2");
        }
    }
}
