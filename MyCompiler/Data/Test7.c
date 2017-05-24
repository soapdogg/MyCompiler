int test7(){
    int a[10];
    int i;
    for(i = 0; i < 10; ++i){
        a[i] = 0;
    }
    int x = 0;
    int y = 1;
    int z = 5;
    a[x] = x = y + z;
    return a[x];
}