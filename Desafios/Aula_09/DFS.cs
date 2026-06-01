static bool DFS(
    Dictionary<string,List<string>> grafo,
    string atual,
    string destino,
    HashSet<string> visitados)
{
    Console.Write(atual);

    if(atual == destino)
        return true;

    visitados.Add(atual);

    foreach(string vizinho in grafo[atual])
    {
        if(!visitados.Contains(vizinho))
        {
            Console.Write(" -> ");

            if(DFS(
                grafo,
                vizinho,
                destino,
                visitados))
            {
                return true;
            }
        }
    }

    return false;
}