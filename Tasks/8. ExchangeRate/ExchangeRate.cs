
namespace RssFeed
{
    class Program
    {



         




        Double exchangeRate(string from,string to)
        {
            string url = "http://www.nbg.ge/rss.php";

            XmlReader reader = XmlReader.Create(url);


            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            string summary = "";
           foreach(SyndicationItem item in feed.Items)
            {

                summary = item.Summary.Text;

            }
            
           
            int index;
            double sum, sum2;
            string value;
             
            double fromcalculate(string fro)
            {
                string a;
                double calc;
                index = summary.IndexOf(from);
               
                value = summary.Substring(index);
                Regex regex = new Regex("[0-9]*[.][0-9]+");
                Match match = regex.Match(value);
               
                a = Convert.ToString(match);
                calc = Double.Parse(a, CultureInfo.InvariantCulture);
                Console.WriteLine(calc);
                return calc;
            }
            sum = fromcalculate(from);

            double tocalculate(string fro)
            {
                string a;
                double calc;
                index = summary.IndexOf(to);
                
                value = summary.Substring(index);
                Regex regex = new Regex("[0-9]*[.][0-9]+");
                Match match = regex.Match(value);
                a = Convert.ToString(match);
                calc = Double.Parse(a, CultureInfo.InvariantCulture);
                Console.WriteLine(calc);
                return calc;
            }
            sum2 = tocalculate(to);
            string[] correct = new string[]
            {
                   "1 AED=10 არაბეთის გაერთიანებული საამიროების დირჰამი ",
                   "1 AMD=1000 სომხური დრამი ",
                   "1 CNY=10 ჩინური იუანი",
                   "1 CZK=10 ჩეხური კრონა",
                   "1 DKK=10 დანიური კრონი",
                   "1 EGP=10 ეგვიპტური გირვანქა ",
                   "1 HKD=10 ჰონკონგური დოლარი",
                   "1 HUF=100 უნგრული ფორინტი",
                   "1 ILS=10 ისრაელის შეკელი",
                   "1 INR=100 ინდური რუპია",
                   "1 IRR=10000 ირანული რიალი",
                   "1 ISK=100 ისლანდიური კრონი",
                   "1 JPY=100 იაპონური იენი",
                   "1 KGS=100 ყირგიზული სომი",
                   "1 KRW=1000 სამხრეთ კორეული ვონი",
                   "1 KZD=100 ყაზახური ტენგე",
                   "1 MDL=10 მოლდოვური ლეი",
                   "1 NOK=10 ნორვეგიული კრონი",
                   "1 PLD=10 პოლონური ზლოტი",
                   "1 QAR=10 კატარული რიალი",
                   "1 RON=10 რუმინული ლეი",
                   "1 RSD=100 სერბიული დინარი",
                   "1 RUS=100 რუსული რუბლი",
                   "1 SEK=10 შვედური კრონი",
                   "1 TJS=10 ტაჯიკური სომონი",
                   "1 TMT=10 თურქმენული მანათი",
                   "1 UAH=10 უკრაინული გრივნა",
                   "1 UZS=1000 უზბეკური სუმი",
                   "1 ZAR=10 სამხრეთაფრიკული რანდი"

            };
            for (int i=0;i<correct.Length;i++)
            { Console.WriteLine(correct[i]); }
            double src1;
            
            src1 = sum / sum2;       
                       
           
            return src1;          


        }

    }
}
