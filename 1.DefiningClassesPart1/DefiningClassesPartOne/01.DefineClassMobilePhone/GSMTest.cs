/*Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, 
battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). 
Define 3 separate classes (class GSM holding instances of the classes Battery and Display).*/
namespace DefineClassMobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class GSMTest
    {
        public static string dashes = "\n" + new string('-', 40) + "\n";

        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            List<GSM> mobilePhones = new List<GSM>();
            mobilePhones.Add(new GSM("Nokia", "Lumia 520", 1200, "Ivan Ivanov", "samsung", 1200, BatteryType.NiMH, 800, 480, 16000000));
            mobilePhones.Add(new GSM("Samsung", "Galaxy Trend", 300, "Petar Yordanov", "samsung", 1500, BatteryType.LiIon, 800, 480, 16000000));
            mobilePhones.Add(new GSM("HTC", "One", 1180, "Kiril Donchev", "HTC", 2300, BatteryType.LiPo, 800, 480, 16000000));
            mobilePhones.Add(new GSM("Huawei", "Ascend G600", 400, "Gergana Petrova", "ZTE", 1930, BatteryType.LiIon, 960, 540, 16000000));
            mobilePhones.Add(new GSM("Sony", "Xperia Z", 1100, "Krum Bachev", "samsung", 2330, BatteryType.LiIon, 1080, 1920, 16000000));

            Console.WriteLine("{0}List of mobile phones:{0}", dashes);

            foreach (var phone in mobilePhones)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine(GSM.IPhone4S);
            //Tasks 1-7 are done in the code above.

            GSMCallHistoryTest.TestCallHistory(); //Used to hold and display information for Tasks 8-12.
        }
    }

    

    


}