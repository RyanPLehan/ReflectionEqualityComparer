using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Comparer.Core.EqualityComparers
{
    /// <summary>
    /// This is Equality Comparer that uses reflection to acquire public properties and their associated values.
    /// </summary>
    /// <remarks>
    /// Custom attributes are available to ignore specific properties for comparison.
    /// Custom attributes are available to determine which properties are used to create the hashcode.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <author>
    /// Name:   Lehan, Ryan
    /// Date:   05/01/2018
    /// GitHub: 
    /// </author>
    public class ReflectionEqualityComparer<T> : IEqualityComparer<T>
    {

        public bool Equals(T x, T y)
        {
            // Assume both objects are equal
            bool areEqual = true;

            // This is check to see if one parameter is instaniated, but the other is not
            if ((x == null && y != null) ||
                (x != null && y == null))
                areEqual = false;


            if (x != null && y != null)
            {
                var propertyNames = CreatePropertyComparisonList();
                foreach (var propName in propertyNames)
                {
                    // First sign of inequality, exit loop
                    if (!areEqual)
                        break;

                    var xValue = typeof(T).GetProperty(propName).GetValue(x);
                    var yValue = typeof(T).GetProperty(propName).GetValue(y);
                    areEqual = areEqual && AreEqual(xValue, yValue);
                }
            }

            return areEqual;
        }

        public int GetHashCode(T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (obj != null)
            {
                var propertyNames = CreatePropertyHashCodeList();
                foreach (var propName in propertyNames)
                {
                    var value = typeof(T).GetProperty(propName).GetValue(obj);
                    if (value != null)
                        stringBuilder.Append(value.ToString());
                }
            }

            return stringBuilder.ToString().GetHashCode();
        }


        #region Private
        private IEnumerable<string> CreatePropertyComparisonList()
        {
            IList<string> items = new List<string>();

            // Get properties information of the return object type
            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in propertyInfos)
            {
                var attribute = prop.GetCustomAttribute<ReflectionEqualityComparerAttribute>();
                if (!attribute?.Ignore ?? true)
                    items.Add(prop.Name);
            }

            return items;
        }


        private IEnumerable<string> CreatePropertyHashCodeList()
        {
            IList<string> items = new List<string>();

            // Get properties information of the return object type
            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in propertyInfos)
            {
                var attribute = prop.GetCustomAttribute<ReflectionEqualityComparerAttribute>();
                if (attribute?.UseForHashCode ?? false)
                    items.Add(prop.Name);
            }

            return items;
        }


        private bool AreEqual(object xValue, object yValue)
        {
            // Assume both objects are equal
            bool ret = true;

            // This is a check to see see if one value is null and the other is not
            if ((xValue == null && yValue != null) ||
                (xValue != null && yValue == null))
                ret = false;

            if (xValue != null && yValue != null)
                ret = xValue.Equals(yValue);

            return ret;
        }
        #endregion
    }
}
