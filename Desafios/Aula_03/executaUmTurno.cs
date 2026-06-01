Celula executaUmTurno(ListaCircular lista, Celula atual) {
    Celula alvo;
    Celula proximo;
    int dano;
    int usouHabilidade = 0;

    if (lista == NULL || lista->inicio == NULL || atual == NULL) {
        return NULL;
    }

    alvo = buscaInimigoMaisProximo(atual);

    if (alvo == NULL) {
        return atual;
    }

    proximo = atual->prox;
    dano = atual->personagem.dano;

    if (atual->personagem.temHabilidade) {
        if (rand() % 100 < 20) {
            dano = (int)(dano * atual->personagem.habilidade.modificador);
            usouHabilidade = 1;
        }
    }

    if (usouHabilidade) {
        printf("%s usa habilidade %s!\n",
               atual->personagem.nome,
               atual->personagem.habilidade.nome);
    }

    alvo->personagem.vida -= dano;

    printf("%s ataca %s causando %d de dano.\n",
           atual->personagem.nome,
           alvo->personagem.nome,
           dano);

    if (alvo->personagem.vida <= 0) {
        printf("%s foi derrotado!\n", alvo->personagem.nome);

        if (proximo == alvo) {
            proximo = alvo->prox;
        }

        removeDaListaCircular(lista, alvo);
    }

    if (lista->inicio == NULL) {
        return NULL;
    }

    return proximo;
}