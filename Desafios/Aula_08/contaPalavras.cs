using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static List<Dictionary<string, int>> historico =
        new List<Dictionary<string, int>>();

    static Dictionary<string, int>? ultimoTexto = null;

    static void Main()
    {
        int opcao;

        do
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Novo texto");
            Console.WriteLine("2 - Buscar palavra");
            Console.WriteLine("3 - Comparar textos");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");

            opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    NovoTexto();
                    break;

                case 2:
                    BuscarPalavra();
                    break;

                case 3:
                    CompararTextos();
                    break;

                case 4:
                    Console.WriteLine("Tchau!");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 4);
    }

    static void NovoTexto()
    {
        Dictionary<string, int> frequencias =
            new Dictionary<string, int>();

        int totalPalavras = 0;

        Console.WriteLine();
        Console.WriteLine("Digite o texto (linha vazia para encerrar):");

        while (true)
        {
            string? linha = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(linha))
                break;

            linha = NormalizarTexto(linha);

            string[] palavras =
                linha.Split(' ',
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string palavra in palavras)
            {
                totalPalavras++;

                if (frequencias.ContainsKey(palavra))
                    frequencias[palavra]++;
                else
                    frequencias[palavra] = 1;
            }
        }

        ultimoTexto = frequencias;
        historico.Add(frequencias);

        Console.WriteLine();
        Console.WriteLine("=== Resultado ===");
        Console.WriteLine($"Total de palavras: {totalPalavras}");
        Console.WriteLine($"Palavras distintas: {frequencias.Count}");

        Console.WriteLine();
        Console.WriteLine("Top 10 palavras mais frequentes:");

        var top10 = frequencias
            .OrderByDescending(p => p.Value)
            .ThenBy(p => p.Key)
            .Take(10);

        int posicao = 1;

        foreach (var item in top10)
        {
            Console.WriteLine(
                $"{posicao,2}. \"{item.Key}\" - {item.Value} ocorrência(s)");
            posicao++;
        }
    }

    static void BuscarPalavra()
    {
        if (ultimoTexto == null)
        {
            Console.WriteLine("Nenhum texto carregado.");
            return;
        }

        Console.Write("Qual palavra? ");

        string palavra =
            NormalizarTexto(Console.ReadLine()!);

        if (ultimoTexto.ContainsKey(palavra))
        {
            Console.WriteLine(
                $"\"{palavra}\" aparece {ultimoTexto[palavra]} vez(es).");
        }
        else
        {
            Console.WriteLine(
                $"\"{palavra}\" não aparece no texto.");
        }
    }

    static void CompararTextos()
    {
        if (historico.Count < 2)
        {
            Console.WriteLine(
                "É necessário possuir pelo menos dois textos.");
            return;
        }

        Dictionary<string, int> texto1 =
            historico[historico.Count - 2];

        Dictionary<string, int> texto2 =
            historico[historico.Count - 1];

        HashSet<string> conjunto1 =
            new HashSet<string>(texto1.Keys);

        HashSet<string> conjunto2 =
            new HashSet<string>(texto2.Keys);

        conjunto1.IntersectWith(conjunto2);

        Console.WriteLine();
        Console.WriteLine("Palavras em comum:");

        if (conjunto1.Count == 0)
        {
            Console.WriteLine("Nenhuma palavra encontrada.");
            return;
        }

        foreach (string palavra in conjunto1.OrderBy(p => p))
        {
            Console.WriteLine(palavra);
        }
    }

    static string NormalizarTexto(string texto)
    {
        texto = texto.ToLower();

        StringBuilder sb = new StringBuilder();

        foreach (char c in texto)
        {
            if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                sb.Append(c);
        }

        return sb.ToString();
    }
}