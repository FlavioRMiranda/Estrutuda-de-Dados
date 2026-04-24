using System;
namespace BST
{
    class BST
    {
        public Node? Raiz;

        public void Inserir(int valor)
        {
            Raiz = InserirRecursivo(Raiz, valor);
        }
    
       private Node InserirRecursivo(Node? node, int valor)
        {

            if(node == null)
              return new Node(valor);
            
            if(valor < node.Chave)
            {
                node.Esquerda = InserirRecursivo(node.Esquerda,valor);

            }
            else
            {
                node.Direita = InserirRecursivo(node.Direita, valor);
            }

            return node;
        }
    
    //void PrintInOrder(): imprime os valores da árvore em ordem (faça recursivo e iterativo)

    //Recursivo:
        public void PrintInOrder()
        {         
            PrintInOrderRecursivo(Raiz);

        }
        private void PrintInOrderRecursivo(Node? node)
        {
            if(node == null)
              return;
            
            PrintInOrderRecursivo(node.Direita);
            Console.WriteLine(node.Chave);
            PrintInOrderRecursivo(node.Esquerda);

        }

        //Iterativo

   public void InOrderIterative()
{
    Stack<Node> s = new();
    Node? current = Raiz;

    while (current != null || s.Count > 0)
    {
        if (current != null)
        {
            s.Push(current);
            current = current.Esquerda;
        }
        else
        {
            current = s.Pop();
            Console.WriteLine(current.Chave);
            current = current.Direita;
        }
    }
}



//Node Maximo(): retorna o maior valor da árvore (faça recursivo e iterativo)
    
    //Recursivo

    public Node? FindMax(Node? node)
{
    if (node == null)
        return null;

    if (node.Direita == null)
        return node;

    return FindMax(node.Direita);
}

//Iterativo
        public Node? FindMax()
        {
            if(Raiz == null)
              return null;
        Node current = Raiz;
        while(current.Direita != null)
            {
                current = current.Direita;
            }
            return current;
        }


//Node Minimo(): retorna o menor valor da árvore (faça recursivo e iterativo)

    //Recursivo:

    public Node? FindMin(Node? node)
{
    if (node == null)
        return null;

    if (node.Direita == null)
        return node;

    return FindMin(node.Esquerda);
}

//Iterativo:
     public Node? FindMin()
        {
            if(Raiz == null)
              return null;
        Node current = Raiz;
        while(current.Esquerda != null)
            {
                current = current.Esquerda;
            }
            return current;
        }
 

      

        /*
       Além disso, tente implementar um método para imprimir os valores de uma maneira 
       boa para visualização no console.

        */

       public void CoolPrint()
        {
            CoolPrintRecursivo(Raiz, 0);
        }

        private void CoolPrintRecursivo(Node? node,int level)
        {
            if(node == null)
              return;
            
            CoolPrintRecursivo(node.Direita,level + 1);
            Console.WriteLine(new string('*',5) + node.Chave);
            CoolPrintRecursivo(node.Esquerda,level + 1);

        }


    }
}