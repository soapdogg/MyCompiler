int test9(){
    int i = 0;
    int j = 0;
    do {
        if(i == 1){
            j += i;
        }
        else if(i % 2 == 0) j += i;
        else{
           if(i == 9){
                i++;
           } else if(i != 6){
             --i;
             i += j;
           }
        }
        ++i;
    }while(i < 10);

    i = 0;
    while(i < 10) i++;
    return j;
}