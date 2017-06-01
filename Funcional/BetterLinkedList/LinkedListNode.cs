using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    class LinkedListNode<T> : IEquatable<LinkedListNode<T>>
    {

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value { set; get; }

        /// <summary>
        /// Gets or sets the next.
        /// </summary>
        /// <value>The next.</value>
        public LinkedListNode<T> Next { set; get; }

        /// <summary>
        /// Determines whether the specified NSNode is equal to the current node.
        /// </summary>
        /// <param name="other">The NSNode to compare with the current node.</param>
        /// <returns><c>true</c> if the specified NSNode is equal to the current
        /// node; otherwise, <c>false</c>.</returns>
        public bool Equals(LinkedListNode<T> other)
        {
            return Value.Equals(other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:willyOS.NSNode`1"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.NSNode`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.NSNode`1"/>.</returns>
        public override string ToString()
        {
            return string.Format("[NSNode: Value={0}, Next={1}]", Value, Next);
        }
    }
}
