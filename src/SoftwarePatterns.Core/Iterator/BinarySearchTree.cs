using System;
using System.Collections;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Iterator
{
	[Serializable]
	public class BinarySearchTree<T> : IEnumerable<T>
	{
		private readonly IComparer<T> comparer;

		public BinarySearchTree()
		{
			comparer = Comparer<T>.Default;
		}

		public BinarySearchTree(IEnumerable<T> collection) :
			this(collection, Comparer<T>.Default)
		{
		}

		public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
		{
			if (collection == null) throw new ArgumentNullException("collection");
			if (comparer == null) throw new ArgumentNullException("comparer");

			this.comparer = comparer;
			foreach (var item in collection)
				Add(item);
		}

		public BinarySearchTree(BinaryTreeNode<T> root)
		{
			Root = root;
		}

		public BinaryTreeNode<T> Root { get; private set; }

		public void Add(T val)
		{
			var newNode = new BinaryTreeNode<T>(val);
			if (Root == null)
			{
				Root = newNode;
				return;
			}

			Add(Root, newNode);
		}

		public bool Contains(T val)
		{
			return Contains(Root, val);
		}

		public T GetMaximum()
		{
			if (Root == null)
				return default(T);

			var node = Root;
			while (node.Right != null)
				node = node.Right;

			return node.Value;
		}

		public T GetMinimum()
		{
			if (Root == null)
				return default(T);

			var node = Root;
			while (node.Left != null)
				node = node.Left;

			return node.Value;
		}

		private void Add(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
		{
			if (comparer.Compare(node.Value, root.Value) <= 0)
			{
				if (root.Left == null)
					root.Left = node;
				else
					Add(root.Left, node);
			}
			else //node.Value > root.Value
			{
				if (root.Right == null)
					root.Right = node;
				else
					Add(root.Right, node);
			}
		}

		private bool Contains(BinaryTreeNode<T> node, T val)
		{
			if (node == null)
				return false;

			var comparison = comparer.Compare(val, node.Value);
			if (comparison == 0) //val = node.value
				return true;
			else if (comparison < 0) //val < node.Value
				return Contains(node.Left, val);
			else //val > node.Value
				return Contains(node.Right, val);
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (UseBreadFirst)
			{
				return new BinaryTreeEnumeratorBreadthFirstEnumerator<T>(Root);
			}
			return new BinaryTreeEnumerator<T>(Root);
		}

		public bool UseBreadFirst { get; set; }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}