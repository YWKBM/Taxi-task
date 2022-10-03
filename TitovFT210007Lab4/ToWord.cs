using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitovFT210007Lab4
{
    public class ToWord
    {

        static string PluralizeCurrencyWord(int count)
        {
            switch (count % 100)
            {
                case 11:
                case 12:
                case 13:
                case 14:
                    return " рублей";
                default:
                    switch (count % 10)
                    {
                        case 1:
                            return " рубль";
                        case 2:
                        case 3:
                        case 4:
                            return " рубля";
                        default:
                            return " рублей";
                    }
            }
        }

        static string PluralizeThousandPartWord(int thousandPart)
        {
            switch (thousandPart % 100)
            {
                case 11:
                case 12:
                case 13:
                case 14:
                    return " тысяч";
                default:
                    switch (thousandPart % 10)
                    {
                        case 1:
                            return " тысяча";
                        case 2:
                        case 3:
                        case 4:
                            return " тысячи";
                        default:
                            return " тысяч";
                    }
            }
        }


        public string DigitToWord(int count)
        {
            int[] parts = new int[2];

            parts[0] = count / 1000;
            parts[1] = count % 1000;

            string result = "";

            for (int i = 0; i < 2; i++)
            {
                if (parts[i] != 0)
                {

                    if (parts[i] / 100 != 0)
                    {
                        switch (parts[i] / 100)
                        {
                            case 1: result += " сто"; break;
                            case 2: result += " двести"; break;
                            case 3: result += " триста"; break;
                            case 4: result += " четыреста"; break;
                            case 5: result += " пятьсот"; break;
                            case 6: result += " шестьсот"; break;
                            case 7: result += " семьсот"; break;
                            case 8: result += " восемьсот"; break;
                            case 9: result += " девятьсот"; break;
                        }
                    }

                    if (parts[i] % 100 / 10 != 1)
                    {
                        switch (parts[i] % 100 / 10)
                        {
                            case 2: result += " двадцать"; break;
                            case 3: result += " тридцать"; break;
                            case 4: result += " сорок"; break;
                            case 5: result += " пятьдесят"; break;
                            case 6: result += " шестьдесят"; break;
                            case 7: result += " семьдесят"; break;
                            case 8: result += " восемьдесят"; break;
                            case 9: result += " девяносто"; break;
                        }

                        switch (parts[i] % 10)
                        {
                            case 1: if (i == 0) result += " одна"; else result += " один"; break;
                            case 2: if (i == 0) result += " две"; else result += " два"; break;
                            case 3: result += " три"; break;
                            case 4: result += " четыре"; break;
                            case 5: result += " пять"; break;
                            case 6: result += " шесть"; break;
                            case 7: result += " семь"; break;
                            case 8: result += " восемь"; break;
                            case 9: result += " девять"; break;
                        }

                    }
                    else
                    {
                        switch (parts[i] % 100)
                        {
                            case 10: result += " десять"; break;
                            case 11: result += " одиннадцать"; break;
                            case 12: result += " двенадцать"; break;
                            case 13: result += " тринадцать"; break;
                            case 14: result += " четырнадцать"; break;
                            case 15: result += " пятнадцать"; break;
                            case 16: result += " шестнадцать"; break;
                            case 17: result += " семнадцать"; break;
                            case 18: result += " восемннадцать"; break;
                            case 19: result += " девятнадцать"; break;
                        }
                    }
                }

                if ((i == 0) && parts[0] != 0)
                {
                    result += PluralizeThousandPartWord(parts[0]);
                }
                else if (i == 1)
                {
                    result += PluralizeCurrencyWord(count);
                }

            }

            return result.Substring(1, 1).ToUpper() + result.Substring(2, result.Length - 2);
        }
    }
}
