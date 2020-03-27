using System;
using System.Collections;
using System.Collections.Generic;

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
                Console.WriteLine("Error. Incorrect argument count.");
                return;
            }
            if (double.TryParse(args[1], out double X) != true)
            {
                Console.WriteLine("Error. Incorrect argument " + args[1]);
                return;
            }
            if (double.TryParse(args[2], out double x_min) != true)
            {
                Console.WriteLine("Error. Incorrect argument " + args[2]);
                return;
            }
            if (double.TryParse(args[3], out double x_max) != true)
            {
                Console.WriteLine("Error. Incorrect argument " + args[3]);
                return;
            }
            if (int.TryParse(args[4], out int n) != true)
            {
                Console.WriteLine("Error. Incorrect argument " + args[4]);
                return;
            }
            if (x_max < x_min) {Console.WriteLine("Error. X_max is less than X_min"); return; }
            if (n<=0) { Console.WriteLine("Error. N is less or equal to 0"); }
                RPN result = new RPN(args[0]);
            //Console.WriteLine(wynik.ErrorLog);
            if (result.ErrorLog[0] == 'E' && result.ErrorLog[1] == 'r' && result.ErrorLog[2] == 'r') { Console.WriteLine(result.ErrorLog); return; }
            foreach (string token in result.Infix_Tokens_Array)
            {
                Console.Write(token+" ");
            }
            Console.Write("\n");
            foreach (string token in result.Postfix_Tokens_Array)
            {
                Console.Write(token + " ");
            }
            Console.Write("\n");
            Console.WriteLine(RPN.PostfixCalcSingleX(result.Postfix_Tokens_Array, X));
            RPN.PostfixCalcMultiX(result.Postfix_Tokens_Array, X, x_min, x_max, n);
            /*
            Stack S = new Stack();
            S.Push("2,0");
            Console.WriteLine(double.Parse(S.Peek().ToString()));
            */

            /*
            //v testy działania metod klasy v
            //if ("" + args[0][0] + args[0][1] + args[0][2] == "abs") Console.WriteLine("true");

            // v analiza formuły, rozwinięcie skrótów, zmiana do (z góry poprawnej, jeśli to możliwe) formy akceptowalnej przez funkcje klasy
            string InfixTokens;
            InfixTokens = RPN.InfixTokens(args[0]);
            
            // v jeśli wyrzuci błąd, przerwanie działania programu v
            if (InfixTokens[0] == 'E' && InfixTokens[1] == 'r' && InfixTokens[2] == 'r') { Console.WriteLine(InfixTokens);return; }

            // v wypisanie tokenów Infix v
            Console.WriteLine(InfixTokens);
            string[] InfixTokensTab = new string[RPN.InfixTokensCount(InfixTokens)];
            InfixTokensTab = RPN.SplitInfixTokens(InfixTokens,RPN.InfixTokensCount(InfixTokens));
            //for (int i=0; i < InfixTokensTab.Length; i++) Console.WriteLine(InfixTokensTab[i]); // tokeny pojedynczo, jeden pod drugim, podział na podstawie przerw " "


            */
            //Console.WriteLine("Hello World!2");
        }
    }
}
