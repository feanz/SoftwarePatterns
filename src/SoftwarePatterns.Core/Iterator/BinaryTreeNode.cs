using System.Collections;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Iterator
{
	public class BinaryTreeNode<T> 
	{
		public BinaryTreeNode(T val)
		{
			Value = val;
		}

		public BinaryTreeNode<T> Left { get; set; }
		public BinaryTreeNode<T> Right { get; set; }
		public T Value { get; private set; }

		public IEnumerable<BinaryTreeNode<T>> Children()
		{
			if(Left != null)
				yield return Left;
			if(Right != null)
				yield return Right;
		}
	}
}