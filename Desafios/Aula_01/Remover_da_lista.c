#include <stdio.h>
#include <stdlib.h>

struct no {
    int info;
    struct no *prox;
};

struct no* novoNo(int valor) {
    struct no* novo = malloc(sizeof(struct no));
    novo->info = valor;
    novo->prox = NULL;
    return novo;
}

struct no* insert_first(struct no* lista, int valor) {
    struct no* novo = novoNo(valor);
    novo->prox = lista;
    return novo;
}

void print_list(struct no* lista) {
    struct no* curr = lista;

    while (curr != NULL) {
        printf("%d -> ", curr->info);
        curr = curr->prox;
    }

    printf("NULL\n");
}

struct no *remove_last(struct no *lista) {

    if (lista == NULL)
        return NULL;

    if (lista->prox == NULL) {
        free(lista);
        return NULL;
    }

    struct no *curr = lista;

    while (curr->prox->prox != NULL) {
        curr = curr->prox;
    }

    free(curr->prox);
    curr->prox = NULL;

    return lista;
}

int main() {

    struct no *lista = NULL;

    lista = insert_first(lista, 4);
    lista = insert_first(lista, 3);
    lista = insert_first(lista, 2);
    lista = insert_first(lista, 1);

    printf("Lista original:\n");
    print_list(lista);

    lista = remove_last(lista);

    printf("Depois de remover o ultimo:\n");
    print_list(lista);

    return 0;
}