using System;
namespace AVL
{
    public class Tree<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        Node<T> Root = null;

        public Tree()
        {
            Count = 0;
        }

        public int GetBalance(Node<T> nodeToCheck)
        {
            int heightRight;
            int heightLeft;

            if (nodeToCheck.leftNode == null)
            {
                heightLeft = 0;
            }

            else
            {
                heightLeft = nodeToCheck.leftNode.height;
            }

            if (nodeToCheck.rightNode == null)
            {
                heightRight = 0;
            }

            else
            {
                heightRight = nodeToCheck.rightNode.height;
            }

            return heightRight - heightLeft;
        }

        private int GetHeight(Node<T> nodeToCheck)
        {
            int heightRight;
            int heightLeft;

            if (nodeToCheck.leftNode == null)
            {
                heightLeft = 0;
            }

            else
            {
                heightLeft = nodeToCheck.leftNode.height;
            }

            if (nodeToCheck.rightNode == null)
            {
                heightRight = 0;
            }

            else
            {
                heightRight = nodeToCheck.rightNode.height;
            }

            return Math.Max(heightLeft, heightRight) + 1;
        }
        public Node<T> LeftRotation (Node<T> nodeToRotate)
        {
            Node<T> temp = nodeToRotate;
            nodeToRotate = nodeToRotate.rightNode;
            temp.rightNode = nodeToRotate.leftNode;
            nodeToRotate.leftNode = temp;
            temp.height = 1;
            temp.height = GetHeight(temp);
            return nodeToRotate;
        }

        public Node<T> RightRotation (Node<T> nodeToRotate)
        {
            Node<T> temp = nodeToRotate;
            nodeToRotate = nodeToRotate.leftNode;
            temp.leftNode = nodeToRotate.rightNode;
            nodeToRotate.rightNode = temp;
            temp.height = 1;
            temp.height = GetHeight(temp);
            return nodeToRotate;
        }
        private Node<T> Insert(Node<T> nodeToCheck, Node<T> nodeToAdd)
        {
            if (nodeToCheck == null) return nodeToAdd;


            if (nodeToAdd.value.CompareTo(nodeToCheck.value) <= 0)
            {
                nodeToCheck.leftNode = Insert(nodeToCheck.leftNode, nodeToAdd);
            }            
            else
            {
                nodeToCheck.rightNode = Insert(nodeToCheck.rightNode, nodeToAdd);
            }

            nodeToCheck.height = GetHeight(nodeToCheck);
            nodeToCheck.balance = GetBalance(nodeToCheck);
            if (nodeToCheck.balance > 1)
            {
                nodeToCheck = LeftRotation(nodeToCheck); 
            }
            if(nodeToCheck.balance < -1)
            {
                nodeToCheck = RightRotation(nodeToCheck);
            }
            return nodeToCheck;

        }
        
        public void UserInsert(T value)
        {
            Count++;
            var nodeToAdd = new Node<T>(value);
            Root = Insert(Root, nodeToAdd);
        }
    }
}
