int test16(){
    int x[10];
    int y = 0;
    x[0] = 34;
    ++x[y];
    x[y]++;
    return x[y];
}