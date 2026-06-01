using System;
using System.Collections.Generic;
using System.Diagnostics;

class NoBST
{
    public int Valor;
    public NoBST? Esquerda;
    public NoBST? Direita;

    public NoBST(int valor)
    {
        Valor = valor;
    }
}

class BST
{
    public NoBST? Raiz;

    public void Inserir(int valor)
    {
        Raiz = Inserir(Raiz, valor);
    }

    private NoBST Inserir(NoBST? no, int valor)
    {
        if (no == null)
            return new NoBST(valor);

        if (valor < no.Valor)
            no.Esquerda = Inserir(no.Esquerda, valor);
        else if (valor > no.Valor)
            no.Direita = Inserir(no.Direita, valor);

        return no;
    }

    public int Altura()
    {
        return Altura(Raiz);
    }

    private int Altura(NoBST? no)
    {
        if (no == null)
            return 0;

        return 1 + Math.Max(Altura(no.Esquerda), Altura(no.Direita));
    }
}

class NoAVL
{
    public int Valor;
    public int Altura;
    public NoAVL? Esquerda;
    public NoAVL? Direita;

    public NoAVL(int valor)
    {
        Valor = valor;
        Altura = 1;
    }
}

class AVL
{
    public NoAVL? Raiz;

    public void Inserir(int valor)
    {
        Raiz = Inserir(Raiz, valor);
    }

    private NoAVL Inserir(NoAVL? no, int valor)
    {
        if (no == null)
            return new NoAVL(valor);

        if (valor < no.Valor)
            no.Esquerda = Inserir(no.Esquerda, valor);
        else if (valor > no.Valor)
            no.Direita = Inserir(no.Direita, valor);
        else
            return no;

        AtualizarAltura(no);

        int balanceamento = FatorBalanceamento(no);

        if (balanceamento > 1 && valor < no.Esquerda!.Valor)
            return RotacaoDireita(no);

        if (balanceamento < -1 && valor > no.Direita!.Valor)
            return RotacaoEsquerda(no);

        if (balanceamento > 1 && valor > no.Esquerda!.Valor)
        {
            no.Esquerda = RotacaoEsquerda(no.Esquerda!);
            return RotacaoDireita(no);
        }

        if (balanceamento < -1 && valor < no.Direita!.Valor)
        {
            no.Direita = RotacaoDireita(no.Direita!);
            return RotacaoEsquerda(no);
        }

        return no;
    }

    private int Altura(NoAVL? no)
    {
        return no == null ? 0 : no.Altura;
    }

    private void AtualizarAltura(NoAVL no)
    {
        no.Altura = 1 + Math.Max(Altura(no.Esquerda), Altura(no.Direita));
    }

    private int FatorBalanceamento(NoAVL no)
    {
        return Altura(no.Esquerda) - Altura(no.Direita);
    }

    private NoAVL RotacaoDireita(NoAVL y)
    {
        NoAVL x = y.Esquerda!;
        NoAVL? temp = x.Direita;

        x.Direita = y;
        y.Esquerda = temp;

        AtualizarAltura(y);
        AtualizarAltura(x);

        return x;
    }

    private NoAVL RotacaoEsquerda(NoAVL x)
    {
        NoAVL y = x.Direita!;
        NoAVL? temp = y.Esquerda;

        y.Esquerda = x;
        x.Direita = temp;

        AtualizarAltura(x);
        AtualizarAltura(y);

        return y;
    }

    public int AlturaArvore()
    {
        return Altura(Raiz);
    }
}

class Program
{
    static Random random = new Random();

    static List<int> GerarNumerosDistintos(int quantidade)
    {
        HashSet<int> numeros = new HashSet<int>();

        while (numeros.Count < quantidade)
        {
            numeros.Add(random.Next(1, quantidade * 10 + 1));
        }

        return new List<int>(numeros);
    }

    static void ExecutarSimulacao()
    {
        Console.Write("Digite a quantidade de amostras: ");
        int A = int.Parse(Console.ReadLine()!);

        Console.Write("Digite a quantidade de elementos para cada amostra: ");
        int N = int.Parse(Console.ReadLine()!);

        double somaAlturaBST = 0;
        double somaAlturaAVL = 0;

        double somaTempoBST = 0;
        double somaTempoAVL = 0;

        Stopwatch cronometro = new Stopwatch();

        for (int i = 0; i < A; i++)
        {
            List<int> valores = GerarNumerosDistintos(N);

            BST bst = new BST();

            cronometro.Restart();

            foreach (int valor in valores)
            {
                bst.Inserir(valor);
            }

            cronometro.Stop();
            somaTempoBST += cronometro.Elapsed.TotalMilliseconds;

            AVL avl = new AVL();

            cronometro.Restart();

            foreach (int valor in valores)
            {
                avl.Inserir(valor);
            }

            cronometro.Stop();
            somaTempoAVL += cronometro.Elapsed.TotalMilliseconds;

            somaAlturaBST += bst.Altura();
            somaAlturaAVL += avl.AlturaArvore();
        }

        double mediaBST = somaAlturaBST / A;
        double mediaAVL = somaAlturaAVL / A;
        double mediaGeralAltura = (mediaBST + mediaAVL) / 2.0;

        double mediaTempoBST = somaTempoBST / A;
        double mediaTempoAVL = somaTempoAVL / A;
        double mediaGeralTempo = (mediaTempoBST + mediaTempoAVL) / 2.0;

        Console.WriteLine();
        Console.WriteLine($"Experimento com A = {A} e N = {N}");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Altura média geral:              {mediaGeralAltura:F2}");
        Console.WriteLine($"Tempo médio geral de construção: {mediaGeralTempo:F4} ms");
        Console.WriteLine("---");
        Console.WriteLine($"Altura média BST comum:          {mediaBST:F2}");
        Console.WriteLine($"Tempo médio de construção BST:   {mediaTempoBST:F4} ms");
        Console.WriteLine("---");
        Console.WriteLine($"Altura média AVL:                {mediaAVL:F2}");
        Console.WriteLine($"Tempo médio de construção AVL:   {mediaTempoAVL:F4} ms");
        Console.WriteLine("----------------------------------");
    }

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Menu: 1) nova simulação ou 2) sair");
            Console.Write("> ");
            opcao = int.Parse(Console.ReadLine()!);

            if (opcao == 1)
            {
                ExecutarSimulacao();
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Tchau!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }

            Console.WriteLine();

        } while (opcao != 2);
    }
}