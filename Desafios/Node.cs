using System;
namespace BST
{
    class Node
    {
        public int Chave{get;set;}
        public Node? Esquerda{get;set;}
        public Node? Direita{get;set;}

        public Node(int chave)
        {
            
            Chave = chave;
            Esquerda = null;
            Direita = null;
        }
    }
}
