using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class Lista<T> : IList<T>
    {
    /// <summary>
		/// The head of the list.
		/// </summary>
		private LinkedListNode<T> _head;

		/// <summary>
		/// The current node, used to avoid adding nodes before the head
		/// </summary>
		private LinkedListNode<T> _current;

		/// <summary>
		/// The size.
		/// </summary>
		private int _size = 0;

		/// <summary>
		/// Gets or sets the <see cref="T:willyOS.WList`1"/> at the specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		public T this[int index] {
			get {
				if (Count == 0) {
					throw new IndexOutOfRangeException();
				}
				var pointer = _head;
				IndexInRangeCheck(index);
				while (index > 0) {
					pointer = pointer.Next;
					index--;
				}
				return pointer.Value;
			}

			set {
				if (Count == 0) {
					throw new IndexOutOfRangeException();
				}
				var pointer = _head;
				IndexInRangeCheck(index);
				while (index > 0) {
					pointer = pointer.Next;
					index--;
				}

				pointer.Value = value;
			}
		}

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>The count.</value>
		public int Count {
			get {
				return _size;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:willyOS.NSList"/> is read only.
		/// </summary>
		/// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
		public bool IsReadOnly {
			get {
				return false;
			}
		}

		public Lista() {
			_head = null;
		}

		/// <summary>
		/// Add a new Node to the list.
		/// </summary>
		public void Add(T item) {

			// This is a more verbose implementation to avoid adding nodes to the head of the list
			var node = new LinkedListNode<T>() {
				Value = item
			};

			if (_head == null) {
				// This is the first node. Make it the head
				_head = node;
			} else {
				// This is not the head. Make it current's next node.
				_current.Next = node;
			}

			// Makes newly added node the current node
			_current = node;

			_size++;

			// This implementation is simpler but adds nodes in reverse order. It adds nodes to the head of the list
		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		public void Clear() {
			_head = null;
			_size = 0;
		}

		/// <summary>
		/// Contains the specified item.
		/// </summary>
		/// <returns>The contains.</returns>
		/// <param name="item">Item.</param>
		public bool Contains(T item) {
			return Find(item) != null;
			//return IndexOf(item) != -1;
		}

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="index">Array index.</param>
		public void CopyTo(T[] array, int index = 0) {
			foreach (T i in this) {
				if (index < array.Length) {
					array.SetValue(i, index);
					index++;
				}
			}
		}

		/// <summary>
		/// Safes the copy to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		public void SafeCopyTo(ref T[] array, int arrayIndex = 0) {
			if (array == null) {
				throw new ArgumentException("The destination array cannot be null.");
			}
			if (arrayIndex < 0) {
				throw new ArgumentException("The index where the list will be copied must be possitive.");
			}

			if ((array.Length - arrayIndex) < Count) {
				Array.Resize(ref array, array.Length + (Count - (array.Length - arrayIndex)));
			}

			foreach (T i in this) {
				array.SetValue(i, arrayIndex);
				arrayIndex++;
			}
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<T> GetEnumerator() {
			for (int i = 0; i < Count; i++) {
				yield return this[i];
			}
		}

		/// <summary>
		/// Indexs the of.
		/// </summary>
		/// <returns>The of.</returns>
		/// <param name="item">Item.</param>
		public int IndexOf(T item) {
			if (Count == 0) {
				return -1;
			}
			EqualityComparer<T> c = EqualityComparer<T>.Default;
			int index = 0;
			if (item == null) {
				for (LinkedListNode<T> x = _head; x != null; x = x.Next) {
					if (x.Value == null)
						return index;
					index++;
				}
			} else {
				for (LinkedListNode<T> x = _head; x != null; x = x.Next) {
					if (c.Equals(item, x.Value))
						return index;
					index++;
				}
			}
			return -1;
		}

		/// <summary>
		/// Find the specified value.
		/// </summary>
		/// <returns>The find.</returns>
		/// <param name="value">Value.</param>
		internal LinkedListNode<T> Find(T value) {
			LinkedListNode<T> node = _head;
			EqualityComparer<T> c = EqualityComparer<T>.Default;
			if (node != null) {
				if (value != null) {
					do {
						if (c.Equals(node.Value, value)) {
							return node;
						}
						node = node.Next;
					} while (node != null);
				} else {
					do {
						if (node.Value == null) {
							return node;
						}
						node = node.Next;
					} while (node != null);
				}
			}
			return null;
		}

		/// <summary>
		/// Insert the specified index and item.
		/// </summary>
		/// <returns>The insert.</returns>
		/// <param name="index">Index.</param>
		/// <param name="item">Item.</param>
		public void Insert(int index, T item) {
			IndexInRangeCheck(index);

			var newNode = new LinkedListNode<T>();
			newNode.Value = item;
			if (index == 0) {
				newNode.Next = _head;
				_head = newNode;
			} else {
				var aux = _head;
				while (index > 1) //for(int i = 0; i < posicion; i++) {nodoAux = nodoAux.Siguiente;}
				{
					aux = newNode.Next;
					index--;
				}
				newNode.Next = aux.Next;
				aux.Next = newNode;
			}
			_size++;
		}

		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <returns>The remove.</returns>
		/// <param name="item">Item.</param>
		public bool Remove(T item) {
			var index = IndexOf(item);
			if (index >= 0) {
				RemoveAt(IndexOf(item));
				return true;
			}
			return false;
		}

		/// <summary>
		/// Removes at index.
		/// </summary>
		/// <param name="index">Index.</param>
		public void RemoveAt(int index) {
			IndexInRangeCheck(index);

			if (index == 0) {
				// removing the first element must be handled specially
				_head = _head.Next;
			} else {
				// removing some element further down in the list;
				// traverse to the node before the one we want to remove
				var pointer = _head;
				for (int i = 0; i < index - 1; i++) {
					pointer = pointer.Next;
				}

				// change its next pointer to skip past the offending node
				pointer.Next = pointer.Next.Next;
			}
			_size--;
		}

		/// <summary>
		/// System.s the collections. IE numerable. get enumerator.
		/// </summary>
		/// <returns>The collections. IE numerable. get enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.NSList`1"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:willyOS.NSList`1"/>.</returns>
		public override string ToString() {
			var pointer = _head;
			StringBuilder aux = new StringBuilder("List -> ");

			while (pointer != null) {
				aux.Append("[" + pointer.Value + "] -> ");
				pointer = pointer.Next;
			}
			return aux.ToString();
		}

		/// <summary>
		/// Indexs the in range check.
		/// </summary>
		/// <param name="index">Index.</param>
		private void IndexInRangeCheck(int index) {
			if (index > Count || index < 0) {
				throw new IndexOutOfRangeException("Trying to access the list with the index: " + index);
			}
		}
	}
}
