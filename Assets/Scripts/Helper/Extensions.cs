using System;
using System.Collections.Generic;
 
public static class Extentions
{
    public static List<T> GetClone<T>(this List<T> source)
    {
        return source.GetRange(0, source.Count);
    }
}