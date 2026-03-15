#include <stdio.h>
#include <stdlib.h>

typedef struct No {
    int valor;
    struct No* prox;
} No;

void bubbleSortLista(No* inicio) {
    int trocou;
    No* ptr1;
    No* lptr = NULL;

    if (inicio == NULL)
        return;

    do {
        trocou = 0;
        ptr1 = inicio;

        while (ptr1->prox != lptr) {
            if (ptr1->valor > ptr1->prox->valor) {

                int temp = ptr1->valor;
                ptr1->valor = ptr1->prox->valor;
                ptr1->prox->valor = temp;

                trocou = 1;
            }

            ptr1 = ptr1->prox;
        }

        lptr = ptr1;

    } while (trocou);
}

void imprimirLista(No* inicio) {
    while (inicio != NULL) {
        printf("%d ", inicio->valor);
        inicio = inicio->prox;
    }
    printf("\n");
}

int main() {

    No* n1 = malloc(sizeof(No));
    No* n2 = malloc(sizeof(No));
    No* n3 = malloc(sizeof(No));
    No* n4 = malloc(sizeof(No));

    n1->valor = 8; n1->prox = n2;
    n2->valor = 3; n2->prox = n3;
    n3->valor = 5; n3->prox = n4;
    n4->valor = 1; n4->prox = NULL;

    printf("Lista original:\n");
    imprimirLista(n1);

    bubbleSortLista(n1);

    printf("Lista ordenada:\n");
    imprimirLista(n1);

    return 0;
}