using System;

namespace Tree{

public class BST
{
    public Node Root;
    public void Insert(int key)
    {
        Root = InsertLeaf(Root, key);
    }

    private Node InsertLeaf(Node? node, int key)
    {
        if(node == null)
        return new Node(key);

        if(key < node.Key)
        node.Left = InsertLeaf(node.Left,key);
        else
        node.Right = InsertLeaf(node.Right,key);

        return node;
        
    }

    public Node Search(int key)
    {
        return RecursiveSearch(Root, key);
        
    }

    private Node RecursiveSearch(Node root, int key)
    {
        if(root == null || root.Key == key)
        return root;

        if(key < root.Key)
        return RecursiveSearch(root.Left,key);
        else
        return RecursiveSearch(root.Right,key);
    }

    public void StructurePrint(Node node,int nivel = 0)
    {
         if(node == null)
         return;

            
                StructurePrint(node.Right,nivel + 1);
                Console.WriteLine(new string(' ', nivel *4) + node.Key);
                StructurePrint(node.Left,nivel + 1);
                
            
        
    }

}

}