void removeDaListaCircular(ListaCircular lista, Celula alvo) {
    Celula atual;
    Celula anterior;

    if (lista == NULL || lista->inicio == NULL || alvo == NULL) {
        return;
    }

    if (lista->inicio == alvo && lista->fim == alvo) {
        free(alvo);
        lista->inicio = NULL;
        lista->fim = NULL;
        return;
    }

    anterior = lista->fim;
    atual = lista->inicio;

    do {
        if (atual == alvo) {
            anterior->prox = atual->prox;

            if (atual == lista->inicio) {
                lista->inicio = atual->prox;
            }

            if (atual == lista->fim) {
                lista->fim = anterior;
            }

            free(atual);
            return;
        }

        anterior = atual;
        atual = atual->prox;

    } while (atual != lista->inicio);
}