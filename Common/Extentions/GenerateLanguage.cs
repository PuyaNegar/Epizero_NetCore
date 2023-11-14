using Common.Functions;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extentions
{
  public static  class GenerateLanguage
    {
        public static string GetLanguage(this int value)
        {
            try
            {
                if (value == 1)
                    return "زبان ترک";
                else if (value == 2)
                    return "زبان فارسی";
                else
                    return "زبان انگلسی";
            }
            catch (Exception)
            {
                throw new CustomException(SystemCommonMessage.IdentifierIsNotValid);
            }
        }
    }
}
