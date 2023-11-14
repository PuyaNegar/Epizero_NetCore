using System;
using System.Collections;

namespace Common.Functions
{
   public static class RandomSymbolCreator 
    {
        public static ArrayList Create()
        { 
                var SymbolList = new ArrayList();
                for (int i = 65; i < 91; i++)
                {
                    char c = Convert.ToChar(i);
                    SymbolList.Add(c);
                    c = Convert.ToChar(i + 32);
                    SymbolList.Add(c);
                }
                for (int i = 48; i < 58; i++)
                {
                    char c = Convert.ToChar(i);
                    SymbolList.Add(c);
                }
                return SymbolList; 
        }
    }
}
