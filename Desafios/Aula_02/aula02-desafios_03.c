#include <stdio.h>
#include <stdlib.h>

typedef struct No {
    int valor;
    struct No* prox;
} No;

No* insereOrdenado(No* inicio, int numero);

void imprimeLista(No* inicio) {
    while (inicio != NULL) {
        printf("%d ", inicio->valor);
        inicio = inicio->prox;
    }
    printf("\n");
}

int main() {

    No* lista = NULL;

    lista = insereOrdenado(lista, 5);
    lista = insereOrdenado(lista, 2);
    lista = insereOrdenado(lista, 8);
    lista = insereOrdenado(lista, 4);

    imprimeLista(lista);

    return 0;
}

No* insereOrdenado(No* inicio, int numero) {

    No* novo = malloc(sizeof(No));
    novo->valor = numero;
    novo->prox = NULL;

    if (inicio == NULL || numero < inicio->valor) {
        novo->prox = inicio;
        return novo;
    }

    No* atual = inicio;

    while (atual->prox != NULL && atual->prox->valor < numero) {
        atual = atual->prox;
    }

    novo->prox = atual->prox;
    atual->prox = novo;

    return inicio;
}