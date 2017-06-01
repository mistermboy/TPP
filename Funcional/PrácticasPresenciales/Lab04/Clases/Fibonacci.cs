using System;
using System.Collections;
using System.Collections.Generic;

namespace Clases {

    /// <summary>
    /// Class that implements the IEnumerable<int> interface to provide the Fibonacci sequence
    /// </summary>
     class Fibonacci: IEnumerable<int> {

        /// <summary>
        /// Number of elements in the sequence
        /// </summary>
        private int numberOfElements;

        public Fibonacci(int numberOfElements) {
            this.numberOfElements = numberOfElements;
        }

        /// <summary>
        /// Explicit implementation of the generic interface.
        /// Notice that IEnumerable<int>.GetEnumerator is used instead of IEnumerable.GetEnumerator,
        /// because there are two versions of GetEnumerator (the one in IEnumerable<T> and the one in IEnumerable)
        /// </summary>
        IEnumerator<int> IEnumerable<int>.GetEnumerator() {
            return new FibonacciEnumerator(numberOfElements);
        }

        /// <summary>
        /// Explicit implementation of the polymorphic interface.
        /// Notice that IEnumerable.GetEnumerator is used instead of IEnumerable<T>.GetEnumerator,
        /// because there are two versions of GetEnumerator (the one in IEnumerable<T> and the one in IEnumerable)
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return new FibonacciEnumerator(numberOfElements);
        }

    } //  Fibonacci class

} // namespace
