﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extentions
{
   public static class ListExtension
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
