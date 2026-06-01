Celula buscaInimigoMaisProximo(Celula atual) {
    Celula aux;
    int tipoInimigo;

    if (atual == NULL) {
        return NULL;
    }

    if (atual->personagem.tipo == JOGADOR) {
        tipoInimigo = MONSTRO;
    } else {
        tipoInimigo = JOGADOR;
    }

    aux = atual->prox;

    while (aux != atual) {
        if (aux->personagem.tipo == tipoInimigo) {
            return aux;
        }

        aux = aux->prox;
    }

    return NULL;
}