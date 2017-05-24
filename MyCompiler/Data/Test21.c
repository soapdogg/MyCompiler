long test21(){
    long x = 0;
    long y = 1;
    long z = 7;
    int i;
    int j, k;
    k = 2;
    while (k < 345){
        for(j = 0; j < 100; ++j){
            if (x > 1000 || z % 2 == 1) z++;
            else if(y == 1 && z == 7) z += 34;
            else z = 3;


            i = 54;
            do{
            x += z * y;
            y++;
            ++i;
            }while(i  < 100);
        }
        if(k % 2 == 1 && !(z > 1194 || 697 < k)) k += i * j;
        else k += i + j;
    }
    return x;
}