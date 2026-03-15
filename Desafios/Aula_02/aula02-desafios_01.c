#include <stdio.h>
#include <stdlib.h>

typedef struct No {
    int valor;
    struct No* prox;
} No;

int somaLista(No* inicio) {
    int soma = 0;
    No* atual = inicio;

    while (atual != NULL) {
        soma += atual->valor;
        atual = atual->prox;
    }

    return soma;
}

int main() {
    No* n1 = malloc(sizeof(No));
    No* n2 = malloc(sizeof(No));
    No* n3 = malloc(sizeof(No));

    n1->valor = 5;
    n1->prox = n2;

    n2->valor = 10;
    n2->prox = n3;

    n3->valor = 7;
    n3->prox = NULL;

    printf("Soma da lista: %d\n", somaLista(n1));

    free(n1);
    free(n2);
    free(n3);

    return 0;
}