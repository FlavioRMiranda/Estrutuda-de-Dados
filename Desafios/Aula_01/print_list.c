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
    struct no* atual = lista;

    while (atual != NULL) {
        printf("%d -> ", atual->info);
        atual = atual->prox;
    }

    printf("NULL\n");
}

int main() {

    struct no* lista = NULL;

    lista = insert_first(lista, 30);
    lista = insert_first(lista, 20);
    lista = insert_first(lista, 10);

    printf("Lista ligada:\n");
    print_list(lista);

    return 0;
}