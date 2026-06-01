using System;
using System.Collections.Generic;

public class Pokemon
{
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }

    public Pokemon(string nome, string tipo, int vida, int ataque, int defesa)
    {
        Nome = nome;
        Tipo = tipo;
        Vida = vida;
        Ataque = ataque;
        Defesa = defesa;
    }

    public void ExibirStatus()
    {
        Console.WriteLine($"{Nome} | Tipo: {Tipo} | Vida: {Vida} | Ataque: {Ataque} | Defesa: {Defesa}");
    }

    public virtual void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        alvo.Vida -= dano;

        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Console.WriteLine($"{Nome} atacou {alvo.Nome} e causou {dano} de dano.");
        Console.WriteLine($"{alvo.Nome} agora está com {alvo.Vida} de vida.\n");
    }
}

public class PokemonFogo : Pokemon
{
    public PokemonFogo(string nome, int vida, int ataque, int defesa)
        : base(nome, "Fogo", vida, ataque, defesa)
    {
    }

    public override void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        dano += 2;

        alvo.Vida -= dano;

        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Console.WriteLine($"{Nome} usou ataque de fogo!");
        Console.WriteLine($"{Nome} atacou {alvo.Nome} e causou {dano} de dano.");
        Console.WriteLine($"{alvo.Nome} agora está com {alvo.Vida} de vida.\n");
    }
}

public class PokemonAgua : Pokemon
{
    public PokemonAgua(string nome, int vida, int ataque, int defesa)
        : base(nome, "Água", vida, ataque, defesa)
    {
    }

    public override void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        alvo.Vida -= dano;

        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Vida += 2;

        Console.WriteLine($"{Nome} usou ataque de água!");
        Console.WriteLine($"{Nome} atacou {alvo.Nome} e causou {dano} de dano.");
        Console.WriteLine($"{Nome} recuperou 2 de vida.");
        Console.WriteLine($"{alvo.Nome} agora está com {alvo.Vida} de vida.\n");
    }
}

public class PokemonGrama : Pokemon
{
    private static Random random = new Random();

    public PokemonGrama(string nome, int vida, int ataque, int defesa)
        : base(nome, "Grama", vida, ataque, defesa)
    {
    }

    public override void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        int chance = random.Next(1, 101);

        if (chance <= 20)
        {
            dano *= 2;
            Console.WriteLine($"{Nome} acertou um ataque crítico!");
        }

        alvo.Vida -= dano;

        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Console.WriteLine($"{Nome} usou ataque de grama!");
        Console.WriteLine($"{Nome} atacou {alvo.Nome} e causou {dano} de dano.");
        Console.WriteLine($"{alvo.Nome} agora está com {alvo.Vida} de vida.\n");
    }
}

public class Treinador
{
    public string Nome { get; set; }
    public LinkedList<Pokemon> Pokemons { get; set; }

    public Treinador(string nome)
    {
        Nome = nome;
        Pokemons = new LinkedList<Pokemon>();
    }

    public void AdicionarPokemon(Pokemon p)
    {
        Pokemons.AddLast(p);
    }

    public void ListarPokemons()
    {
        int indice = 0;

        Console.WriteLine($"Pokémon de {Nome}:");

        foreach (Pokemon p in Pokemons)
        {
            Console.Write($"{indice} - ");
            p.ExibirStatus();
            indice++;
        }

        Console.WriteLine();
    }

    public Pokemon EscolherPokemon(int indice)
    {
        int contador = 0;

        foreach (Pokemon p in Pokemons)
        {
            if (contador == indice)
                return p;

            contador++;
        }

        return null;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Treinador ash = new Treinador("Ash");
        Treinador misty = new Treinador("Misty");

        ash.AdicionarPokemon(new PokemonFogo("Charmander", 20, 7, 3));
        ash.AdicionarPokemon(new PokemonGrama("Bulbasaur", 22, 6, 4));

        misty.AdicionarPokemon(new PokemonAgua("Squirtle", 20, 8, 3));
        misty.AdicionarPokemon(new PokemonGrama("Chikorita", 21, 6, 3));

        ash.ListarPokemons();
        misty.ListarPokemons();

        Pokemon pokemonAsh = ash.EscolherPokemon(0);
        Pokemon pokemonMisty = misty.EscolherPokemon(0);

        Console.WriteLine($"{ash.Nome} escolheu {pokemonAsh.Nome}!");
        Console.WriteLine($"{misty.Nome} escolheu {pokemonMisty.Nome}!\n");

        while (pokemonAsh.Vida > 0 && pokemonMisty.Vida > 0)
        {
            pokemonAsh.Atacar(pokemonMisty);

            if (pokemonMisty.Vida <= 0)
                break;

            pokemonMisty.Atacar(pokemonAsh);
        }

        if (pokemonAsh.Vida > 0)
            Console.WriteLine($"{pokemonAsh.Nome} venceu a batalha!");
        else
            Console.WriteLine($"{pokemonMisty.Nome} venceu a batalha!");
    }
}