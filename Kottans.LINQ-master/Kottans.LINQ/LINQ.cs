using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kottans.LINQ
{
    public static class LINQ
    {
        public static bool All<T>(this IEnumerable<T> source, Predicate <T> predicate  )
        {
            if (source == null || predicate == null)
                throw new ArgumentNullException();
            foreach (var element in source)
            {
                if (!predicate(element)) return false;
            }
            return true;
        }

        public static bool Any<T>(this IEnumerable<T> source, Predicate<T> predicate  )
        {
            if (source == null || predicate == null)
                throw new ArgumentNullException();
            foreach (var element in source)
            {
                if (predicate(element)) return true;
            }
            return false;
        }

        public static bool Any<T>(this IEnumerable<T> source)
        {
            return source.Any( n => n!=null);
        }

        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Func<T, T> predicate)
        {
            if (source == null || predicate == null)
                throw new ArgumentNullException();

            foreach (var element in source)
            {
                yield return predicate(element);
            }

        }
        //public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Func<T, int , T> predicate)
        //{
        //    if (source == null || predicate == null)
        //        throw new ArgumentNullException();
            
        //    foreach (var element in source)
        //    {
        //        yield return predicate(element, index);
        //    }

        //}
    }
}
