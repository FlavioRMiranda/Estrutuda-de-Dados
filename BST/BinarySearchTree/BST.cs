using System;

namespace DataStructures.Trees.BST{
public class BST
{
public Node? Root;
 
 //Metodo para inserir um nó na Arvoce
 public void Insert(int value)
        {
            
          Root = RecursiveInsert(Root,value);

        }
//Metodo para chamada recursiva
        private Node  RecursiveInsert(Node? node, int value)
        {
            if(node == null)
             return new Node(value);

             if(value < node.Chave)
            {
                node.Left = RecursiveInsert(node.Left, value);
            }
             else
              node.Right = RecursiveInsert(node.Right,value);

            return node;

        }
public void InOrder()
    {
      InOrderTraversal(Root);
    }

private void InOrderTraversal(Node? node)
        {
            if(node != null)
            {            
                InOrderTraversal(node.Left);
                Console.WriteLine(node.Chave);
                InOrderTraversal(node.Right);
            }
        }


public void PreOrder()
{
    PreOrderTraversal(Root);
}

private void PreOrderTraversal(Node? node)
{
    if (node != null)
    {
        Console.WriteLine(node.Chave);       // 1. Raiz
        PreOrderTraversal(node.Left);        // 2. Esquerda
        PreOrderTraversal(node.Right);       // 3. Direita
    }
}

public void PosOrder()
{
    PosOrderTraversal(Root);
}

private void PosOrderTraversal(Node? node)
{
    if (node != null)
    {
        PosOrderTraversal(node.Left);        // 2. Esquerda
        PosOrderTraversal(node.Right);       // 3. Direita
        Console.WriteLine(node.Chave);       // 1. Raiz

    }
}

   public void PrintTree()
    {
      PrintTreeRecursive(Root,0);
    }

   private void PrintTreeRecursive(Node? node, int level)
    {
      if(node == null)
       return;
   PrintTreeRecursive(node.Right, level + 1);
Console.WriteLine(new string(' ', 12 + level * 6) + node.Chave);
PrintTreeRecursive(node.Left, level + 1);
    }


public void Delete(int value)
        {
            
          Root = RecursiveDelete(Root,value);

        }
//Metodo para chamada recursiva
        private Node?  RecursiveDelete(Node? node, int value)
        {
            if(node == null)

             return null;
               
             if(value < node.Chave)
            {
                node.Left = RecursiveDelete(node.Left, value);
            }
             else if(value > node.Chave)
             {
              node.Right = RecursiveDelete(node.Right,value);
             }
      else
      {
        if(node.Left == null && node.Right == null)
        return null;
      

      if(node.Left == null)
      
        return node.Right;
      
      if(node.Right == null);
      
        return node.Left;
      

      Node minNode = FindMin(node.Right);
      node.Chave = minNode.Chave;

      node.Right = RecursiveDelete(node.Right, minNode.Chave);
 
        }

        return node;


}


private Node FindMin(Node node)
    {
      while(node.Left != null)
      node = node.Left;

      return node;
    }
}
}