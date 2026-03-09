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

struct no *remove_value(struct no *lista, int value) {

    if (lista == NULL)
        return NULL;

    // caso o valor esteja no primeiro nó
    if (lista->info == value) {
        struct no *temp = lista->prox;
        free(lista);
        return temp;
    }

    struct no *curr = lista;

    while (curr->prox != NULL && curr->prox->info != value) {
        curr = curr->prox;
    }

    if (curr->prox != NULL) {
        struct no *temp = curr->prox;
        curr->prox = temp->prox;
        free(temp);
    }

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
    lista = remove_value(lista, 3);

    printf("Depois de remover 3:\n");
    print_list(lista);

    return 0;
}