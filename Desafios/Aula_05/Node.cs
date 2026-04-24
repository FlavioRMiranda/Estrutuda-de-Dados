using System;

namespace Tree

{
public class Node
{
    public int Key {get;set;}
    public Node? Left {get;set;}
    public Node? Right{get;set;}

    //Construtor
    public Node (int key)
        {
            this.Key = key;
        }
    }

  }
