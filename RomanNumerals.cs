using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public static class RomanNumeralExtension
{
    public static Dictionary<int, string> romans;

    public static void FillDictionary()
    {
        romans = new Dictionary<int, string>();
        romans.Add(1, "I");
        romans.Add(4, "IV");
        romans.Add(5, "V");
        romans.Add(9, "IX");
        romans.Add(10, "X");
        romans.Add(40, "XL");
        romans.Add(50, "L");
        romans.Add(90, "XC");
        romans.Add(100, "C");
        romans.Add(400, "CD");
        romans.Add(500, "D");
        romans.Add(900, "CM");
        romans.Add(1000, "M");
    }

   
    //es un método de extensión
    public static string ToRoman(this int value)
    {
       FillDictionary();

       var roman = new StringBuilder();
       var valor = value;
       foreach ((int tvalue, string troman) in romans.OrderByDescending(x => x.Key))
       {
           if (value >= tvalue)
           {
               for (int i = 0; i < (value / tvalue); i++)
                   roman.Append(troman);
               value %= tvalue;
           }
       }
       return  roman.ToString();
    }

    public static bool IsValue(int value)
    {
        return romans.ContainsKey(value);
    }
    
}