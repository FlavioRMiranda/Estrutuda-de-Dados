static void Main()
{
    var grafo = CriarMapa();

    int opcao;

    do
    {
        Console.WriteLine();
        Console.WriteLine(
            "1 - Listar cidades");
        Console.WriteLine(
            "2 - Conexão direta");
        Console.WriteLine(
            "3 - Existe rota (DFS)");
        Console.WriteLine(
            "4 - Menor rota (BFS)");
        Console.WriteLine(
            "5 - Sair");

        opcao =
            int.Parse(Console.ReadLine());

        switch(opcao)
        {
            case 1:
                ListarCidades(grafo);
                break;

            case 2:
                VerificarConexaoDireta(grafo);
                break;

            case 3:
                Console.Write("Origem: ");
                string origem =
                    Console.ReadLine();

                Console.Write("Destino: ");
                string destino =
                    Console.ReadLine();

                Console.Write("DFS visitando: ");

                bool encontrou =
                    DFS(
                        grafo,
                        origem,
                        destino,
                        new HashSet<string>());

                Console.WriteLine();

                if(encontrou)
                    Console.WriteLine(
                        "Rota encontrada!");
                else
                    Console.WriteLine(
                        "Rota NÃO encontrada.");

                break;

            case 4:

                Console.Write("Origem: ");
                origem =
                    Console.ReadLine();

                Console.Write("Destino: ");
                destino =
                    Console.ReadLine();

                MenorRota(
                    grafo,
                    origem,
                    destino);

                break;
        }

    } while(opcao != 5);

    Console.WriteLine("Boa viagem!");
}