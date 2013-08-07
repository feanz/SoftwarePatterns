using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using SoftwarePatterns.Core.Iterator;
using Xunit;

namespace SoftwarePatterns.Tests.Iterator
{
	//				  5
	//			   /    \
	//			  1      8 
	//			   \    / 
	//		        4  6
	//			   /
	//			  3
	public class BinaryTreeTests
	{
		[Fact]
		public void StartEmpty()
		{
			var tree = new BinarySearchTree<int>();

			Assert.Null(tree.Root);
		}

		[Fact]
		public void StoresValueInRootNode()
		{
			var tree = new BinarySearchTree<int> { 1 };

			Assert.Equal(1, tree.Root.Value);
		}

		public class Enumerable
		{
			[Fact]
			public void ReturnedInOrderRegardlessOfhowAdded()
			{
				var tree = new BinarySearchTree<int> { 5, 1, 4, 3, 8, 6 };

				var list = tree.ToArray();

				Assert.Equal(new List<int> { 1, 3, 4, 5, 6, 8 }, list);
			}

			[Fact]
			public void ReturnedBreadthFirst()
			{
				var tree = new BinarySearchTree<int> { 5, 1, 4, 3, 8, 6 };

				tree.UseBreadFirst = true;

				var list = tree.ToArray();

				Assert.Equal(new List<int> { 5, 1, 8, 4, 6, 3 }, list);
			}
		}

		public class AddMethod
		{
			[Fact]
			public void StoresGreatValueInRightTree()
			{
				var tree = new BinarySearchTree<int> {1, 2};

				Assert.Equal(2, tree.Root.Right.Value);
			}

			[Fact]
			public void StoresLesserValueInLeftTree()
			{
				var tree = new BinarySearchTree<int> {5, 1};

				Assert.Equal(1, tree.Root.Left.Value);
			}

			[Fact]
			public void StoresSecondLesserValueInChildsChild()
			{
				var tree = new BinarySearchTree<int> {10, 5, 1};
				Assert.Equal(1, tree.Root.Left.Left.Value);
			}
		}
	}
}