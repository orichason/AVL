using System;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> AVL = new Tree<int>();

            AVL.UserInsert(5);
            AVL.UserInsert(4);
            AVL.UserInsert(3);
            AVL.UserInsert(2);
            AVL.UserInsert(1);
                ;
        }
    }
}
