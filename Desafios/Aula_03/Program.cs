using System;

namespace Tree{

class Program
{

    public static void Main(string[] args){
    BST bst = new BST();
     
    int[] keys = {50,25,77,20,30,62,81,5,7};
      foreach(int v in keys)
            {
                bst.Insert(v);               
            }

 
    bst.StructurePrint(bst.Root, 0);

    int searchedValue = 62;

    Node search = bst.Search(searchedValue);

    if(search != null)
    Console.WriteLine($"Found: {search.Key}");
    else
    Console.WriteLine($"{searchedValue} not found");

    searchedValue = 81;

    Node search2 = bst.Search(searchedValue);

    if(search2 != null)
    Console.WriteLine($"Encontrado: {search2.Key}");
    else
    Console.WriteLine($"{searchedValue} not found");

}
}
}
