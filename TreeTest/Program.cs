using System;
using System.Collections.Generic;
using System.Linq;
using TreeTest.Collections;

namespace TreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");

            //NTree<int> tree = new NTree<int>(0);
            //IEnumerable<int> list = Enumerable.Range(1, 10);

            //foreach (int num in list)
            //{
            //    tree.AddChild(num);
            //}

            TreeNode<int> root = new TreeNode<int>(1);
            TreeNode<int> treeResult = recursiveModTree(20, root);

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        static TreeNode<int> recursiveModTree(int value, TreeNode<int> node)
        {
            List<int> divisorList = Factor(value);

            if(divisorList.Count() > 2)
            {
                foreach(int divisor in divisorList)
                {
                    if(value != divisor)
                    {
                        recursiveModTree(divisor, node.AddChild(divisor));
                    }
                }
                return node;
            }
            return node;
        }

        static List<int> Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }
    }
}
