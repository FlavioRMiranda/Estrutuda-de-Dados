static Dictionary<string, List<string>> CriarMapa()
{
    return new Dictionary<string, List<string>>
    {
        { "São Paulo", new List<string>
            {
                "Rio de Janeiro",
                "Curitiba",
                "Belo Horizonte"
            }
        },

        { "Rio de Janeiro", new List<string>
            {
                "São Paulo",
                "Belo Horizonte",
                "Vitória"
            }
        },

        { "Belo Horizonte", new List<string>
            {
                "São Paulo",
                "Rio de Janeiro",
                "Brasília"
            }
        },

        { "Curitiba", new List<string>
            {
                "São Paulo",
                "Florianópolis"
            }
        },

        { "Florianópolis", new List<string>
            {
                "Curitiba",
                "Porto Alegre"
            }
        },

        { "Porto Alegre", new List<string>
            {
                "Florianópolis"
            }
        },

        { "Brasília", new List<string>
            {
                "Belo Horizonte",
                "Goiânia"
            }
        },

        { "Goiânia", new List<string>
            {
                "Brasília"
            }
        },

        { "Vitória", new List<string>
            {
                "Rio de Janeiro"
            }
        },

        { "Salvador", new List<string>
            {
                "Recife"
            }
        },

        { "Recife", new List<string>
            {
                "Salvador",
                "Fortaleza"
            }
        },

        { "Fortaleza", new List<string>
            {
                "Recife"
            }
        }
    };
}