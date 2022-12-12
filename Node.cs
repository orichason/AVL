using System;
namespace AVL
{
    public class Node<T>
    {
        public T value;
        public Node<T> leftNode;
        public Node<T> rightNode;
        public int height;
        public int balance;

        public Node(T Value, Node<T> LeftNode, Node<T> RightNode)
        {
            value = Value;
            leftNode = LeftNode;
            rightNode = RightNode;
            height = 1;

        }

        public Node(T Value)
        {
            value = Value;
            height = 1;
        }

      
    }
}
