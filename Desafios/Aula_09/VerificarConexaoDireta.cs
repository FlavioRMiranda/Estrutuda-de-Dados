static void VerificarConexaoDireta(
    Dictionary<string,List<string>> grafo)
{
    Console.Write("Cidade 1: ");
    string cidade1 = Console.ReadLine();

    Console.Write("Cidade 2: ");
    string cidade2 = Console.ReadLine();

    if(grafo.ContainsKey(cidade1) &&
       grafo[cidade1].Contains(cidade2))
    {
        Console.WriteLine(
            $"{cidade1} e {cidade2} possuem conexão direta!");
    }
    else
    {
        Console.WriteLine(
            $"{cidade1} e {cidade2} NÃO possuem conexão direta.");
    }
}