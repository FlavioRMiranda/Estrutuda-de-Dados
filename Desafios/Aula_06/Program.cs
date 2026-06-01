using System;

namespace BST
{
    public class Program
    {
        static void Main(string[] args)
        {
            BST bst = new BST();
            bst.Inserir(40);
            bst.Inserir(20);


         bst.CoolPrint();
           Console.WriteLine("==============");
      Node? max = bst.FindMax();
     Console.WriteLine("O node com a maior chave é o : {0}",max.Chave);
      Console.WriteLine("==============");
     //      Node? min = bst.FindMin();
   //   Console.WriteLine(min.Chave);
 //         bst.CoolPrint();
        }
    }
}
