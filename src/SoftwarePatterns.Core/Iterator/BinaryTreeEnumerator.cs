using System.Collections;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Iterator
{
	public class BinaryTreeEnumeratorBreadthFirstEnumerator<T> : IEnumerator<T>
	{
		private readonly BinaryTreeNode<T> root;
		private BinaryTreeNode<T> current;
		private Queue<IEnumerator<BinaryTreeNode<T>>> _enumerators;

		public BinaryTreeEnumeratorBreadthFirstEnumerator(BinaryTreeNode<T> root)
		{
			this.root = root;
		}

		public void Dispose()
		{
			_enumerators = null;
			current = null;
		}

		public bool MoveNext()
		{
			if (current == null)
			{
				Reset();
				current = root;
				Current = current.Value;
				_enumerators = new Queue<IEnumerator<BinaryTreeNode<T>>>();				
				_enumerators.Enqueue(current.Children().GetEnumerator());
				return true;
			}
			while (_enumerators.Count > 0)
			{
				var enumerator = _enumerators.Peek();
				if (enumerator.MoveNext())
				{
					current = enumerator.Current;
					Current = current.Value;
					_enumerators.Enqueue(current.Children().GetEnumerator());
					return true;
				}
				_enumerators.Dequeue();
			}
			return false;
		}

		public void Reset()
		{
			_enumerators = null;
			current = null;
		}

		public T Current { get; private set; }

		object IEnumerator.Current
		{
			get { return Current; }
		}
	}

	public class BinaryTreeEnumerator<T> : IEnumerator<T>
	{
		private Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

		public BinaryTreeEnumerator(BinaryTreeNode<T> root)
		{
			if (root == null)
				return; //empty root = Enumerable.Empty<T>()

			PushLeftBranch(root);
		}

		private void PushLeftBranch(BinaryTreeNode<T> node)
		{
			while (node != null)
			{
				stack.Push(node);
				node = node.Left;
			}
		}

		public T Current { get; private set; }

		public void Dispose()
		{
			stack = null; //help GC
		}

		public bool MoveNext()
		{
			if (stack.Count == 0)
				return false;

			var node = stack.Pop();
			Current = node.Value;

			if (node.Right != null)
				PushLeftBranch(node.Right);

			return true;
		}

		public void Reset()
		{
			stack.Clear();
		}

		object IEnumerator.Current
		{
			get { return Current; }
		}
	}
}