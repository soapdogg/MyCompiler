int test1(){
    int a ;
        {
            int b = 5 ;
            {
                int c = 10 ;
                {
                    a = b + c ;
                }
            }
        }
    return a ;
}