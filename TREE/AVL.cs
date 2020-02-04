using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week10
{
    class AVL<T>:BinSearchTree<T> where T:IComparable
    {
        private Node<T> oldRoot;
        private Node<T> newRoot;

        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }
       
        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right.BalanceFactor > 0)
            {
                rotateRight(ref tree.Right);
            }
            oldRoot = tree;
            newRoot = oldRoot.Right;
            oldRoot.Right= newRoot.Left;
            newRoot.Left = oldRoot;

            tree = newRoot;
        }

        
        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left.BalanceFactor <0)
            {
                rotateLeft(ref tree.Left);
            }
            oldRoot = tree;
            newRoot = oldRoot.Left;
            oldRoot.Left = newRoot.Right;
            newRoot.Right = oldRoot;

            tree = newRoot;

        }
            private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);

            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem(item, ref tree.Right);
            }

            tree.BalanceFactor = height(tree.Left) - height(tree.Right);
        

            if (tree.BalanceFactor <= -2) {
                
                rotateLeft(ref tree);

            }
            if (tree.BalanceFactor >= 2)
            {
                rotateRight(ref tree);
            }

        }
    }
}
