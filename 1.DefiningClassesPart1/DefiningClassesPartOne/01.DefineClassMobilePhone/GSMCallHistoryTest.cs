namespace DefineClassMobilePhone
{
    using System;

    class GSMCallHistoryTest //Task 12
    {
        public static void TestCallHistory()
        {
            GSM mobilePhone = new GSM("Nokia", "Lumia");
            mobilePhone.AddCall("2.12.1013", "12:35", "+35988555666", 69);
            mobilePhone.AddCall("30.10.1013", "22:19", "+35988866555", 37);
            mobilePhone.AddCall("31.12.1013", "23:59", "+35988616161", 129);
            mobilePhone.AddCall("1.2.1014", "6:12", "+35988245361", 251);

            Console.WriteLine("{0}This is information about the calls:\n", GSMTest.dashes);

            foreach (var call in mobilePhone.calls)
            {
                Console.WriteLine(call);
            }

            decimal totalCost = mobilePhone.PriceOfCalls(0.37M);
            Console.WriteLine("Total cost of calls is: {0:C}{1}", totalCost, GSMTest.dashes);

            int maxLengthCall = 0;
            int indexOfMaxCall = 0;

            for (int callIndex = 0; callIndex < mobilePhone.calls.Count; callIndex++)
            {
                if (mobilePhone.calls[callIndex].CallDuaration > maxLengthCall)
                {
                    maxLengthCall = mobilePhone.calls[callIndex].CallDuaration;
                    indexOfMaxCall = callIndex;
                }
            }

            mobilePhone.DeleteCall(indexOfMaxCall);
            Console.WriteLine("{0}List of calls after Longest call deleted!\n", GSMTest.dashes);

            foreach (var call in mobilePhone.calls)
            {
                Console.WriteLine(call);
            }

            totalCost = mobilePhone.PriceOfCalls(0.37M);
            Console.WriteLine("Recalculated cost of calls is: {0:C}{1}", totalCost, GSMTest.dashes);

            mobilePhone.ClearCallHistory();
            Console.WriteLine("{0}History of calls deleted.{0}", GSMTest.dashes);
        }
    }
}
