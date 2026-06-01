static void ListarCidades(
    Dictionary<string,List<string>> grafo)
{
    foreach(var cidade in grafo)
    {
        Console.WriteLine(
            $"{cidade.Key}: " +
            $"[{string.Join(", ", cidade.Value)}]");
    }
}