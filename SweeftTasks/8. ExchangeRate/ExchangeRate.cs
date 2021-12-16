
static double exchangeRate(string from,string to)
        {
           
                if (from.Length != 3 | to.Length != 3)
                {
                    throw new Exception("Entered non validate currency name");
                }
            
            
            string url = "http://www.nbg.ge/rss.php";

            string path = "C:/User/XmlDoument.txt";

            XmlDocument document = new XmlDocument();

            document.Load(url);
            
            var descrip = document.GetElementsByTagName("description");

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(descrip[1].InnerText);
            }


            var list = File.ReadAllLines(path);

            double firstCurr =0, secondCurr=0;

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Contains(from))
                {
                    var curr = list[i + 2].Replace("<td>", string.Empty);
                    curr = curr.Replace("</td>", string.Empty);
                    firstCurr = double.Parse(curr);
                }

                if (list[i].Contains(to))
                {
                    var curr = list[i + 2].Replace("<td>", string.Empty);
                    curr = curr.Replace("</td>", string.Empty);
                    secondCurr = double.Parse(curr);
                }

                if (firstCurr > 0 && secondCurr > 0)
                {
                    break;
                }


            }

            if (firstCurr == 0 || secondCurr == 0)
            {
                throw new Exception("The currency didnot fount");
            }


            return firstCurr / secondCurr;



        }