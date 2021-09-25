
        int minSplit(int amount)
        {
            int one = 1, five = 5, ten = 10, twenty = 20, fifty = 50;
            int quantity1,quantity=0;
           
            if(amount>=fifty)
            {
                quantity1 = amount / fifty;
                quantity += quantity1;
                if (amount % fifty != 0)
                {
                    amount = amount % fifty;
                }
                
                
                   
                
            }
            /////////////////////////////////////
            if (amount >= twenty)
            {
                quantity1 = amount / twenty;
                quantity += quantity1;
                if (amount % twenty != 0)
                {
                    amount = amount % twenty;
                }
                
            }
            //////////////////////////////////////////////
             if (amount >= ten)
             {
                quantity1 = amount / ten;
                quantity += quantity1;
                if (amount % ten != 0)
                {
                    amount = amount % ten;
                }
                
            } 
            //////////////////////////////////////////////////////////////
             if (amount >= five)            
               {
                quantity1 = amount / five;
                quantity += quantity1;
                if (amount % five != 0)
                {
                    amount = amount % five;
                }
               
            }
            ////////////////////////////////////////////////////////////////////
               if (amount >= one)
            {
                quantity1 = amount / one;
                quantity += quantity1;
                if (amount % twenty != 0)
                {
                    amount = amount % one;
                }
                
            }
            return quantity;
        }
       
