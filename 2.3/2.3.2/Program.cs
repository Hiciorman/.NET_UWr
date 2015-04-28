using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //  		4
	        //      3		2
            // 1	5			10	
            //
            //var wordType = GetTypeFromID("word.Application")
            //dynamic word = Activator.CreateInstance(wordType);

            var child1 = new BinaryTreeNode<int> { Data = 1 };
            var child21 = new BinaryTreeNode<int> { Data = 10 };
            var child2 = new BinaryTreeNode<int> { Data = 2 , RightNode=child21};
            var child4 = new BinaryTreeNode<int> { Data = 5 };
            var child3 = new BinaryTreeNode<int> { Data = 3, LeftNode = child1 , RightNode = child4};          
            var root = new BinaryTreeNode<int> { Data = 4, LeftNode = child3, RightNode = child2 };


            // Domyslny enumerator - DFS z uzyciem 'yield'
            Console.WriteLine("DFS (yield): ");
            foreach (var value in root)
                Console.Write(value + " ");

            // DFS
            Console.WriteLine("\nDFS: ");
            var ieDFS = root.GetEnumeratorDFS();
            while (ieDFS.MoveNext())
                Console.Write(ieDFS.Current + " ");

            // BFS z uzyciem 'yield'
            Console.WriteLine("\nBFS (yield): ");
            var ieBFSyield = root.GetEnumeratorBFSyield();
            while (ieBFSyield.MoveNext())
                Console.Write(ieBFSyield.Current + " ");

            // BFS 
            Console.WriteLine("\nBFS: ");
            var ieBFS = root.GetEnumeratorBFS();
            while (ieBFS.MoveNext())
                Console.Write(ieBFS.Current + " ");

            Console.ReadKey();
        }
    }
}
