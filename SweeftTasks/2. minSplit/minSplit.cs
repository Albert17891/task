
        int minSplit(int amount)
        {
            int[] coins = new int[] { 50, 20, 10, 5, 1 };

            int quantLocal, quantity=0;

            foreach (var coin in coins)
            {
                if (amount >= coin)
                {
                    quantLocal = amount / coin;
                    quantity += quantLocal;
                    amount = amount % coin;
                    if (amount > 0)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return quantity;
        }
       
