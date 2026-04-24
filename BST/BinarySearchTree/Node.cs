using System;

namespace DataStructures.Trees.BST{
public class Node
{
    public int Chave {get; set;}
    public Node? Left {get; set;}

    public Node? Right {get; set;}

    public Node(int chave){
            
            Chave = chave;
            Left = null;
            Right = null;
        }
     }
}