using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._2
{
    public class BinaryTreeNode<T> : IEnumerable<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }

        //DFS
        public IEnumerator<T> DFSYield()
        {
            yield return Data;

            if (LeftNode != null)
            {
                foreach (var child in LeftNode)
                    yield return child;
            }
            if (RightNode != null)
            {
                foreach (var child in RightNode)
                    yield return child;
            }
        }

        public IEnumerator<T> BFSYield()
        {
            var q = new Queue<BinaryTreeNode<T>>();
            q.Enqueue(this);

            while (q.Any())
            {
                BinaryTreeNode<T> current = q.Dequeue();
                if (current != null)
                {
                    if (current.LeftNode != null)
                        q.Enqueue(current.LeftNode);
                    if (current.RightNode != null)
                        q.Enqueue(current.RightNode);

                    yield return current.Data;
                }
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return DFSYield();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return DFSYield();
        }

        public IEnumerator<T> GetEnumeratorBFSyield()
        {
            return BFSYield();
        }

        public IEnumerator<T> GetEnumeratorDFS()
        {
            return new EnumeratorDFS(this);
        }

        public IEnumerator<T> GetEnumeratorBFS()
        {
            return new EnumeratorBFS(this);
        }

        public class EnumeratorDFS : IEnumerator<T>
        {
            BinaryTreeNode<T> node = null;
            Stack<BinaryTreeNode<T>> stack;

            public EnumeratorDFS(BinaryTreeNode<T> root)
            {
                this.node = root;
                stack = new Stack<BinaryTreeNode<T>>();
                stack.Push(node);
            }

            public T Current
            {
                get { return node.Data; }
            }

            object IEnumerator.Current
            {
                get { return node; }
            }

            public bool MoveNext()
            {
                try
                {
                    node = stack.Pop();
                }
                catch (Exception e)
                {
                    node = null;
                    return false;
                }

                if (node != null)
                {
                    if (node.RightNode != null)
                        stack.Push(node.RightNode);
                    if (node.LeftNode != null)
                        stack.Push(node.LeftNode);

                    return true;
                }
                return false;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public class EnumeratorBFS : IEnumerator<T>
        {
            BinaryTreeNode<T> node = null;
            Queue<BinaryTreeNode<T>> queue;

            public EnumeratorBFS(BinaryTreeNode<T> root)
            {
                this.node = root;
                queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(node);
            }

            public T Current
            {
                get { return node.Data; }
            }

            object IEnumerator.Current
            {
                get { return node; }
            }

            public bool MoveNext()
            {
                try
                {
                    node = queue.Dequeue();
                }
                catch (Exception e)
                {
                    node = null;
                    return false;
                }

                if (node != null)
                {
                    if (node.LeftNode != null)
                        queue.Enqueue(node.LeftNode);
                    if (node.RightNode != null)
                        queue.Enqueue(node.RightNode);

                    return true;
                }
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}