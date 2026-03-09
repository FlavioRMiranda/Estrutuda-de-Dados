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

struct no *reverse_list(struct no *lista) {

    struct no *prev = NULL;
    struct no *curr = lista;
    struct no *next = NULL;

    while (curr != NULL) {

        next = curr->prox;   // guarda o próximo nó
        curr->prox = prev;   // inverte o ponteiro

        prev = curr;         // avança prev
        curr = next;         // avança curr
    }

    return prev;             // novo início da lista
}

int main() {

    struct no *lista = NULL;

    lista = insert_first(lista, 4);
    lista = insert_first(lista, 3);
    lista = insert_first(lista, 2);
    lista = insert_first(lista, 1);

    printf("Lista original:\n");
    print_list(lista);

    lista = reverse_list(lista);

    printf("Lista invertida:\n");
    print_list(lista);

    return 0;
}