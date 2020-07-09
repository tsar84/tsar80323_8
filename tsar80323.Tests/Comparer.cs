using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using tsar80323.Controllers;
using tsar80323.DAL.Entities;
using Xunit;



namespace tsar80323.Tests
{
    class Comparer<T> : IEqualityComparer<T>
    {
        public static Comparer<T> GetComparer(Func<T, T, bool> func)
        {
            return new Comparer<T>(func);
        }
        Func<T, T, bool> comparerFunction;
        public Comparer(Func<T, T, bool> func)
        {
            comparerFunction = func;
        }
        public bool Equals(T x, T y)
        {
            return comparerFunction(x, y);
        }
        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
