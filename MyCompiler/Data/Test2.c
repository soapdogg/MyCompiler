int test2() {
    int d = 1;
    d = 1 | 2;
    d = d ^ 4;
    d = d & 7;
    d = ~d;
    return d;
}
