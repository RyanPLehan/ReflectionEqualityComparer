using System;

namespace Comparer.Core.EqualityComparers
{
    /// <summary>
    /// Custom attribute to assist the ReflectionEqualityComparer
    /// </summary>
    /// <author>
    /// Name:   Lehan, Ryan
    /// Date:   05/01/2018
    /// GitHub: 
    /// </author>

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ReflectionEqualityComparerAttribute : Attribute
    {
        private bool _ignore = false;
        private bool _hashCode = false;

        public ReflectionEqualityComparerAttribute()
        {
        }

        public bool Ignore
        {
            get { return this._ignore; }
            set { this._ignore = value; }
        }

        public bool UseForHashCode
        {
            get { return this._hashCode; }
            set { this._hashCode = value; }
        }
    }
}
