
        Boolean isProperly (String sequence)
        {
            int result=0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == ')')
                {
                    result++;
                    if(result>0)
                       return false;
                }
                if (sequence[i] == '(') result--;
                
            }
            if (result == 0)

                return true;
            else
                return false;
            
            
        }

    
       