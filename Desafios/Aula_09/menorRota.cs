static void MenorRota(
    Dictionary<string,List<string>> grafo,
    string origem,
    string destino)
{
    Queue<string> fila =
        new Queue<string>();

    HashSet<string> visitados =
        new HashSet<string>();

    Dictionary<string,string> pai =
        new Dictionary<string,string>();

    fila.Enqueue(origem);
    visitados.Add(origem);

    while(fila.Count > 0)
    {
        string atual = fila.Dequeue();

        if(atual == destino)
            break;

        foreach(string vizinho in grafo[atual])
        {
            if(!visitados.Contains(vizinho))
            {
                visitados.Add(vizinho);

                pai[vizinho] = atual;

                fila.Enqueue(vizinho);
            }
        }
    }

    if(!visitados.Contains(destino))
    {
        Console.WriteLine(
            "Não existe rota.");
        return;
    }

    List<string> caminho =
        new List<string>();

    string cidadeAtual = destino;

    while(cidadeAtual != origem)
    {
        caminho.Add(cidadeAtual);
        cidadeAtual = pai[cidadeAtual];
    }

    caminho.Add(origem);

    caminho.Reverse();

    Console.WriteLine(
        $"Menor rota: {string.Join(" -> ", caminho)}");

    Console.WriteLine(
        $"Paradas: {caminho.Count - 1}");
}