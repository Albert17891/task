
        int countVariants(int stearsCount)
        {
            if(stearsCount==1)
            {
                return 1;
            }
            else if(stearsCount==2)
            {
                return 2;
            }
            else
           


            return (countVariants(stearsCount-1)+countVariants(stearsCount-2));
        }
       