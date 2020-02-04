using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week10
{
    class Program
    {
        static void Main(string[] args)
        {
            BinSearchTree<int> bst = new BinSearchTree<int>();
            AVL<int> avl = new AVL<int>();

            avl.InsertItem(50);
            avl.InsertItem(70);
            avl.InsertItem(80);
            //avl.InsertItem(20);

            string buffer2 = "";

            avl.PreOrder(ref buffer2);
            
            Console.WriteLine("Tree in order :" + buffer2);

            bst.InsertItem (23);
            bst.InsertItem(13);
            bst.InsertItem(15);
            bst.InsertItem(68);
            bst.InsertItem(0);
            
            string m = "";

            bst.InOrder(ref m);
            Console.WriteLine("In order visit of the tree" + m);

            Console.WriteLine("Height of tree " + bst.Height());

            Console.WriteLine("Counter is" + bst.Count());
            Console.WriteLine("Contains" + bst.Contains(23));
            Console.WriteLine("Contains" + bst.Contains(44));
            int r = 68;

            string buffer = "";

            bst.InOrder(ref buffer);
            Console.WriteLine("Tree in order"+r+":"+buffer);

            bst.RemoveItem(r);
            buffer = "";
            bst.InOrder(ref buffer);
            Console.WriteLine("Tree in order after removal" + r + ":" + buffer);
            Console.ReadLine();
         
        }
    }
}
