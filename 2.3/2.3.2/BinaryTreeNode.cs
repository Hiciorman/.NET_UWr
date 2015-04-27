using System;
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
            string chuj;
            yield return chuj; 
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return BFSYield();
        }
    }
}
