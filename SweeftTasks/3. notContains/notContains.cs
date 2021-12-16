                                                                            
        int notContains(int[] array)
        {
            int min=array[0];
            for(int i=0;i<array.Length;i++)
            {
                if (array[i] > 0 && array[i]<min)
                {
                    min = array[i];
                    
                }
            }
            
            return min-1;
        }          
        
