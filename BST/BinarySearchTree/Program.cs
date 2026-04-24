using System;

namespace DataStructures.Trees.BST{
public class Program
{

 static void Main(string[] args){
 BST bst = new BST();

 int[] geraChaves = {10,2,4,1,12,11,17};

 foreach(int v in geraChaves)
            {
                bst.Insert(v);
            }
  
 
 
//bst.PrintTree();
bst.InOrder();
Console.WriteLine("----------");
//bst.PreOrder();
Console.WriteLine("----------");
//bst.PosOrder();
//bst.Delete(12);
//bst.PrintTree();



 }
  
}
}

