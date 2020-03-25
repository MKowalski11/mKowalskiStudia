using System;
using System.Collections.Generic;
using System.Text;

namespace mKowalskiStudia
{
    public static class RPN
    {
        public static string Sprawdzenie(string tekst)
        {
            string wynik = "";
            int dlugosc = tekst.Length;
            int nawias = 0;
            //bool ujemna = false;
            bool kropka = false;
            for (int i = 0; i < dlugosc; i++)
            {
                if (nawias < 0) wynik = "Blad konwersji, nawiasy.";
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
                    else if (tekst[i] == '(') { nawias++; continue; }
                    else if (tekst.Length - i >= 6)
                    {
                        if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "sin(") { wynik += "sin("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "cos(") { wynik += "cos("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "tan(") { wynik += "sin("; i += 3; nawias++; continue; }

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
                    else wynik = "Blad konwersji, nieznany symbol na poczatku.";
                }
                else
                {
                    if ((tekst[i] == '0' || tekst[i] == '1' || tekst[i] == '2' || tekst[i] == '3' || tekst[i] == '4' || tekst[i] == '5'
                       || tekst[i] == '6' || tekst[i] == '7' || tekst[i] == '8' || tekst[i] == '9' || tekst[i] == 'x')&&tekst[i-1]=='x') { wynik = "Nieprawidłowy zapis X."; break; }
                    else if(tekst[i] == 'x' &&( tekst[i-1] == '0' || tekst[i - 1] == '1' || tekst[i - 1] == '2' || tekst[i - 1] == '3' || tekst[i - 1] == '4' ||
                        tekst[i - 1] == '5' || tekst[i - 1] == '6' || tekst[i - 1] == '7' || tekst[i - 1] == '8' || tekst[i - 1] == '9')){
                        wynik += "*x";
                        continue;
                    }
                    else if (tekst[i] == '0' || tekst[i] == '1' || tekst[i] == '2' || tekst[i] == '3' || tekst[i] == '4' || tekst[i] == '5'
                       || tekst[i] == '6' || tekst[i] == '7' || tekst[i] == '8' || tekst[i] == '9' || tekst[i] == 'x') { wynik += tekst[i];continue; }
                    else if (tekst[i] == '.' || tekst[i]== ',')
                    {
                        if (i == tekst.Length-1) { wynik = "Kropka/przecinek na koncu. Bez sensu.";break; }
                        else
                        {
                            if ((tekst[i - 1] == '0' || tekst[i - 1] == '1' || tekst[i - 1] == '2' || tekst[i - 1] == '3' || tekst[i - 1] == '4' || tekst[i - 1] == '5'
                       || tekst[i - 1] == '6' || tekst[i - 1] == '7' || tekst[i - 1] == '8' || tekst[i - 1] == '9') && (tekst[i + 1] == '0' || tekst[i + 1] == '1' || tekst[i + 1] == '2' || tekst[i + 1] == '3' || tekst[i + 1] == '4' || tekst[i + 1] == '5'
                       || tekst[i + 1] == '6' || tekst[i + 1] == '7' || tekst[i + 1] == '8' || tekst[i + 1] == '9')) {
                                if (kropka == false) { wynik += "."; kropka = true; continue; }
                                else { wynik = "Dwa przecinki/kropki w jednej liczbie. Nie wolno tak.";break; }
                            }
                            else { wynik = "Przecinek/kropka nie jest w 'srodku' liczby.";break; }
                        }
                    }
                    // v jeśli żadne z powyższych, liczba się skończyła i będzie jakiś znak v
                    kropka = false; // w tej liczbie fizycznie nie wystąpi przecinek po raz drugi
                    if (tekst[i] == '-' && (tekst[i - 1] == '*' || tekst[i - 1] == '/' || tekst[i - 1] == '(' ))
                    {
                        wynik += "(0-1)*";
                        continue;
                    }
                    else if((tekst[i]=='-' || tekst[i]=='+')&&(tekst[i-1]=='-' || tekst[i - 1] == '+')){
                        wynik = "Blad, powtorzenie operanda tego samego stopnia.";
                        break;
                    }
                    else if ((tekst[i] == '*' || tekst[i] == '/' || tekst[i] == '^') && (tekst[i - 1] == '-' || tekst[i - 1] == '+' || tekst[i-1] == '^'))
                    {
                        wynik = "Blad, powtorzenie operanda tego samego stopnia.";
                        break;
                    }
                    else if(tekst[i] == '+' && (tekst[i - 1] == '*' || tekst[i - 1] == '/' || tekst[i - 1] == '('))
                    {
                        continue;
                    }
                    else if (tekst[i]=='+' || tekst[i] == '-' || tekst[i] == '*' || tekst[i] == '/' || tekst[i] == '^') { wynik += tekst[i];continue; }
                    else if (tekst[i] == '(') { nawias++; wynik += tekst[i]; continue; }
                    else if (tekst[i] == ')') { nawias--; wynik += tekst[i]; continue; }
                    else if (tekst.Length - i >= 6)
                    {
                        if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "sin(") { wynik += "sin("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "cos(") { wynik += "cos("; i += 3; nawias++; continue; }
                        else if ("" + tekst[i] + tekst[i + 1] + tekst[i + 2] + tekst[i + 3] == "tan(") { wynik += "sin("; i += 3; nawias++; continue; }

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
                        wynik = "Nieznany symbol."+tekst[i];
                        break;
                    }
                }

            }
            return wynik;
        }
    }
}
