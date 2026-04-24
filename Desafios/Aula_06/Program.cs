using System;

namespace BST
{
    public class Program
    {
        static void Main(string[] args)
        {
            BST bst = new BST();
            bst.Inserir(10);
            bst.Inserir(3);
            bst.Inserir(13);

   //         bst.PrintInOrder();
  //          Console.WriteLine("==============");
      Node? max = bst.FindMax();
      Console.WriteLine(max.Chave);
       Console.WriteLine("==============");
       
          Node? min = bst.FindMin();
      Console.WriteLine(min.Chave);
 //         bst.CoolPrint();
        }
    }
}
