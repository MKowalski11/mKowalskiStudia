using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mKowalskiStudia
{
    public class RPN
    {
        public RPN(string input)
        {
            string tmpString = inputCheck(input);
            string Infix_Tokens_String = InfixTokens(tmpString);
            Console.WriteLine(Infix_Tokens_String);
            string[] Infix_Tokens_Array = new string[InfixTokensCount(Infix_Tokens_String)];
            //Console.WriteLine("InfixTokensCount = " + InfixTokensCount(Infix_Tokens_String));
            Infix_Tokens_Array = SplitInfixTokens(Infix_Tokens_String, InfixTokensCount(Infix_Tokens_String));
            //for (int i = 0; i < Infix_Tokens_Array.Length; i++) Console.WriteLine("InfixToken " + i + " : " + Infix_Tokens_Array[i]);
            string Postfix_Tokens_String = InfixToPostfix(Infix_Tokens_Array);
            string[] Postfix_Tokens_Array = new string[PostfixTokensCount(Postfix_Tokens_String)];
            Postfix_Tokens_Array = SplitPostfixTokens(Postfix_Tokens_String, PostfixTokensCount(Postfix_Tokens_String));
            //for (int i = 0; i < Postfix_Tokens_Array.Length; i++) Console.WriteLine("PostfixToken " + i + " : " + Postfix_Tokens_Array[i]);
        }

        public static string inputCheck(string input)
        {
            int dlugoscInput = input.Length;
            string tekst = "";
            for (int i = 0; i < dlugoscInput; i++)
            {
                if (input[i] != ' ') tekst += input[i];
            }
            string wynik = "";
            int dlugosc = tekst.Length;
            int nawias = 0;
            //bool ujemna = false;
            bool kropka = false;
            for (int i = 0; i < dlugosc; i++)
            {
                if (nawias < 0) wynik = "Error, nawiasy.";
                if (i == 0)
                {
                    if (tekst[i] == '-')
                    {
                        wynik += "(0-1)*";
                        continue;
                    }
                    if (tekst[i] == '+') continue;
                    else if (tekst[i] == '0' || tekst[i] == '1' || tekst[i] == '2' || tekst[i] == '3' || tekst[i] == '4' || tekst[i] == '5'
                       || tekst[i] == '6' || tekst[i] == '7' || tekst[i] == '8' || tekst[i] == '9' || tekst[i] == 'x') { wynik += tekst[i]; continue; }
                    else if (tekst[i] == '(') { nawias++; wynik += '('; continue; }
                    else if (tekst.Length - i >= 6)
                    {
                        if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "sin(") { wynik += "sin("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "cos(") { wynik += "cos("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "tan(") { wynik += "tan("; i += 3; nawias++; continue; }

                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "exp(") { wynik += "exp("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "log(") { wynik += "log("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "abs(") { wynik += "abs("; i += 3; nawias++; continue; }
                        else if (tekst.Length - i >= 7)
                        {
                            if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "sqrt(") { wynik += "sqrt("; nawias++; i += 4; continue; }

                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "sinh(") { wynik += "sinh("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "cosh(") { wynik += "cosh("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "tanh(") { wynik += "tanh("; nawias++; i += 4; continue; }

                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "asin(") { wynik += "asin("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "acos(") { wynik += "acos("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "atan(") { wynik += "atan("; nawias++; i += 4; continue; }
                        }

                    }
                    else wynik = "Error, nieznany symbol na poczatku.";
                }
                else
                {
                    if ((tekst[i] == '0' || tekst[i] == '1' || tekst[i] == '2' || tekst[i] == '3' || tekst[i] == '4' || tekst[i] == '5'
                       || tekst[i] == '6' || tekst[i] == '7' || tekst[i] == '8' || tekst[i] == '9' || tekst[i] == 'x') && tekst[i - 1] == 'x') { wynik = "Error. Nieprawidłowy zapis X."; break; }
                    else if (tekst[i] == 'x' && (tekst[i - 1] == '0' || tekst[i - 1] == '1' || tekst[i - 1] == '2' || tekst[i - 1] == '3' || tekst[i - 1] == '4' ||
                        tekst[i - 1] == '5' || tekst[i - 1] == '6' || tekst[i - 1] == '7' || tekst[i - 1] == '8' || tekst[i - 1] == '9')) {
                        wynik += "*x";
                        continue;
                    }
                    else if (tekst[i] == '0' || tekst[i] == '1' || tekst[i] == '2' || tekst[i] == '3' || tekst[i] == '4' || tekst[i] == '5'
                       || tekst[i] == '6' || tekst[i] == '7' || tekst[i] == '8' || tekst[i] == '9' || tekst[i] == 'x') { wynik += tekst[i]; continue; }
                    else if (tekst[i] == '.' || tekst[i] == ',')
                    {
                        if (i == tekst.Length - 1) { wynik = "Error. Kropka/przecinek na koncu. Bez sensu."; break; }
                        else
                        {
                            if ((tekst[i - 1] == '0' || tekst[i - 1] == '1' || tekst[i - 1] == '2' || tekst[i - 1] == '3' || tekst[i - 1] == '4' || tekst[i - 1] == '5'
                       || tekst[i - 1] == '6' || tekst[i - 1] == '7' || tekst[i - 1] == '8' || tekst[i - 1] == '9') && (tekst[i + 1] == '0' || tekst[i + 1] == '1' || tekst[i + 1] == '2' || tekst[i + 1] == '3' || tekst[i + 1] == '4' || tekst[i + 1] == '5'
                       || tekst[i + 1] == '6' || tekst[i + 1] == '7' || tekst[i + 1] == '8' || tekst[i + 1] == '9')) {
                                if (kropka == false) { wynik += "."; kropka = true; continue; }
                                else { wynik = "Error. Dwa przecinki/kropki w jednej liczbie. Nie wolno tak."; break; }
                            }
                            else { wynik = "Error. Przecinek/kropka nie jest w 'srodku' liczby."; break; }
                        }
                    }
                    // v jeśli żadne z powyższych, liczba się skończyła i będzie jakiś znak v
                    kropka = false; // w tej liczbie fizycznie nie wystąpi przecinek po raz drugi
                    if (tekst[i] == '-' && (tekst[i - 1] == '*' || tekst[i - 1] == '/' || tekst[i - 1] == '('))
                    {
                        wynik += "(0-1)*";
                        continue;
                    }
                    else if ((tekst[i] == '-' || tekst[i] == '+') && (tekst[i - 1] == '-' || tekst[i - 1] == '+')) {
                        wynik = "Error, powtorzenie operanda tego samego stopnia.";
                        break;
                    }
                    else if ((tekst[i] == '*' || tekst[i] == '/' || tekst[i] == '^') && (tekst[i - 1] == '-' || tekst[i - 1] == '+' || tekst[i - 1] == '^'))
                    {
                        wynik = "Error, powtorzenie operanda tego samego stopnia.";
                        break;
                    }
                    else if (tekst[i] == '+' && (tekst[i - 1] == '*' || tekst[i - 1] == '/' || tekst[i - 1] == '('))
                    {
                        continue;
                    }
                    else if (tekst[i] == '+' || tekst[i] == '-' || tekst[i] == '*' || tekst[i] == '/' || tekst[i] == '^') { wynik += tekst[i]; continue; }
                    else if (tekst[i] == '(') { nawias++; wynik += tekst[i]; continue; }
                    else if (tekst[i] == ')') { nawias--; wynik += tekst[i]; continue; }
                    else if (tekst.Length - i >= 6)
                    {
                        if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "sin(") { wynik += "sin("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "cos(") { wynik += "cos("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "tan(") { wynik += "tan("; i += 3; nawias++; continue; }

                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "exp(") { wynik += "exp("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "log(") { wynik += "log("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "abs(") { wynik += "abs("; i += 3; nawias++; continue; }
                        else if (tekst.Length - i >= 7)
                        {
                            if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "sqrt(") { wynik += "sqrt("; nawias++; i += 4; continue; }

                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "sinh(") { wynik += "sinh("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "cosh(") { wynik += "cosh("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "tanh(") { wynik += "tanh("; nawias++; i += 4; continue; }

                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "asin(") { wynik += "asin("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "acos(") { wynik += "acos("; nawias++; i += 4; continue; }
                            else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] + tekst[i + 4] == "atan(") { wynik += "atan("; nawias++; i += 4; continue; }
                        }

                    }
                    else
                    {
                        wynik = "Error. Nieznany symbol." + tekst[i];
                        break;
                    }
                }

            }
            return wynik;
        }
        public static string InfixTokens(string input)
        {
            string inputText;
            inputText = inputCheck(input);
            if (inputText[0] == 'E' && inputText[1] == 'r' && inputText[2] == 'r') return inputText;
            //bool negative = false;
            string result = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == '(' && inputText[i + 1] == '0' && inputText[i + 2] == '-' && inputText[i + 3] == '1' && inputText[i + 4] == ')' && inputText[i + 5] == '*') { result += '-'; i += 5; continue; }
                else if (inputText[i] == '(' || inputText[i] == ')' || inputText[i] == '+' || inputText[i] == '-' || inputText[i] == '*' || inputText[i] == '/' || inputText[i] == '^') { result += (" " + inputText[i] + " "); continue; }
                else if (inputText[i] == '0' || inputText[i] == '1' || inputText[i] == '2' || inputText[i] == '3' || inputText[i] == '4' || inputText[i] == '5' || inputText[i] == '6' || inputText[i] == '7' ||
                    inputText[i] == '8' || inputText[i] == '9' || inputText[i] == 'x' || inputText[i] == '.') { result += inputText[i]; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "sin(") { result += "sin"; i += 2; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "cos(") { result += "cos"; i += 2; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "tng(") { result += "cos"; i += 2; continue; }

                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "log(") { result += "log"; i += 2; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "abs(") { result += "abs"; i += 2; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "exp(") { result += "exp"; i += 2; continue; }

                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "sqrt") { result += "sqrt"; i += 3; continue; }

                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "asin") { result += "asin"; i += 3; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "acos") { result += "acos"; i += 3; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "atan") { result += "atan"; i += 3; continue; }

                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "sinh") { result += "sinh"; i += 3; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "cosh") { result += "cosh"; i += 3; continue; }
                else if ("" + inputText[i] + inputText[i + 1] + inputText[i + 2] + inputText[i + 3] == "tanh") { result += "tanh"; i += 3; continue; }
                else { result = "Error. Unknown: " + inputText[i]; return result; }
            }
            return result;
        }
        public static int InfixTokensCount(string input)
        {
            int TabCount = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    if (i == 0) continue;
                    if (i == input.Length - 1) continue;
                    if (input[i + 1] == ' ') continue;
                    TabCount++;
                }
            }
            return TabCount;
        }
        public static string[] SplitInfixTokens(string input, int TabCount)
        {
            string[] tab = new string[TabCount];
            int tokensInArray = 0;
            string tmpString = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0 && input[i] == ' ') continue;
                if (i == input.Length-1 && input[i] == ' ') continue;
                if (input[i] == ' ')
                {
                    if (input[i - 1] == ' ') continue;
                    tab[tokensInArray] = tmpString;
                    //Console.WriteLine("Token : " + tokensInArray + " : " + tmpString);
                    tokensInArray++;
                    tmpString = "";
                    continue;
                }
                tmpString += input[i];
            }
            tab[tokensInArray] = tmpString;
            //Console.WriteLine("Token : " + tokensInArray + " : " + tmpString);
            tokensInArray++;
            return tab;
        }
        public static string InfixToPostfix(string[] t)
        {
            string result= "";
            Queue Q = new Queue();
            Stack S = new Stack();
            Dictionary<string, int> D = new Dictionary<string, int>
            {
                {"abs",4 },{"log",4 },{"exp",4 },{"-abs",4 },{"-log",4 },{"-exp",4 },
                {"sin",4 },{"cos",4 },{"tan",4 },{"-sin",4 },{"-cos",4 },{"-tan",4 },
                {"asin",4 },{"acos",4 },{"atan",4 },{"-asin",4 },{"-acos",4 },{"-atan",4 },
                {"sinh",4 },{"cosh",4 },{"tanh",4 },{"-sinh",4 },{"-cosh",4 },{"-tanh",4 },
                {"sqrt",4 },{"-sqrt",4},{"^",3},{"*",2},{"/",2},{"+",1},{"-",1 },{"(",0}
            };
            for(int i = 0; i < t.Length; i++)
            {
                //Console.Write("Test dla: "+t[i]+": ");
                if (t[i] == "(") S.Push(t[i]);
                else if (t[i] == ")")
                {
                    while (S.Peek().ToString() != "(")
                    {
                        Q.Enqueue(S.Pop());
                    }
                    S.Pop();
                }
                else if (D.ContainsKey(t[i]))
                {
                    while (S.Count>0 && D[t[i]]<=D[S.Peek().ToString()])
                    {
                        Q.Enqueue(S.Pop());
                    }
                    S.Push(t[i]);
                }
                else Q.Enqueue(t[i]);
                //Console.Write(t[i] + "\n");
            }
            while (S.Count > 0)
            {
                Q.Enqueue(S.Pop());
            }
            foreach (string token in Q)
            {
                result += token + " ";
            }
            Console.WriteLine(result);
            return result;
        }
        public static int PostfixTokensCount(string input)
        {
            int TabCount = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    if (i == 0 || i == input.Length - 1) continue;
                    
                    TabCount++;
                }
            }
            return TabCount;
        }
        public static string[] SplitPostfixTokens(string input, int TabCount)
        {
            string[] tab = new string[TabCount];
            int tokensInArray = 0;
            string tmpString = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    tab[tokensInArray] = tmpString;
                    tokensInArray++;
                    tmpString = "";
                    continue;
                }
                tmpString += input[i];
            }
            //tab[tokensInArray] = tmpString;
            //tokensInArray++;
            return tab;
        }
        public static double PostfixCalcSingleX(string[] input, double X) {

            return 0.0;
        }
    }
}
