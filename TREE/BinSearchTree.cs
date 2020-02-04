using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week10
{
    class BinSearchTree<T> : BinTree<T> where T : IComparable
    {

        public BinSearchTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);

        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);
            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
        }
        public int Height()
        {

            if (root == null)
            {
                return 0;
            }
            else
            {
                return height( root);
            }

        }

        protected int height( Node<T> tree)
        {
            if (tree == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(height( tree.Left), height( tree.Right));

            }
        }

        public int Count()
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return count(ref root);
            }
        }

        private int count(ref Node<T> tree)
        {

            if (tree == null)
            {
                return 0;
            }

            else
            {
                int counter = 1;
                counter += count(ref tree.Left);
                counter += count(ref tree.Right);
                return counter;
            }

        }



        public Boolean Contains(T item)
        //Return true if the item is contained in the BSTree, false 	  //otherwise.
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                return contains(item,ref root);
            }
        }

        private Boolean contains(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                return false;
            }

            else if (item.CompareTo(tree.Data) < 0)
            {
                contains(item, ref tree.Right);

            }
            else if (item.CompareTo(tree.Data) > 0)
            {

                contains(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) == 0)
            {
                return true;
            }
            return false;
        }

        public void RemoveItem(T item)
        {

            removeItem(item, ref root);

        }
        private T leastItem( Node<T> tree)
        {
            if (tree.Left == null)
            {
                return tree.Data;
            }
            else
            {
                return leastItem(tree.Left);
            }
        }

        
        private void removeItem(T item, ref Node<T> tree)
        {

                if (item.CompareTo(tree.Data) < 0)
                removeItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                removeItem(item, ref tree.Right);
            else if (item.CompareTo(tree.Data) == 0)
            {
                if (tree.Left == null && tree.Right == null)
                {
                    tree = null;
                }

                else if (tree.Left == null)
                {
                    tree = tree.Right;
                }
                else if (tree.Right == null)
                {

                    tree = tree.Left;
                }
                else
                {
                    // int leastItem = 0;
                    T newRoot = leastItem(tree.Right);
                    tree.Data = newRoot;
                    removeItem(newRoot, ref tree.Right);

                }

            }
            
          

        }

    }
     
}