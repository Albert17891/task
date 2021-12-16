
        Boolean isPalindrome(String text)
        {
            string[] clean = new string[] { ","," ",";",":","-","?","!" };
            string Tone,Ttwo;
           
          
            foreach(var a in clean)
            {
                text = text.Replace(a, string.Empty);
            }
           
            Ttwo = text.ToLower();
           
            char[] vs1 = Ttwo.ToCharArray();
            Array.Reverse(vs1);            
            Tone = new string(vs1);
         
            if(Tone==Ttwo)
            {
                return true;
            }
            else
            {
                return false;
            }
          
         }
        }

        
