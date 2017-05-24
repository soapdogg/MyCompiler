int test6(){
    int a[10];
    int x = 9;
    int y = 1;
    int z = 0;
    a[x=y+z] = x;
    return a[x];
}