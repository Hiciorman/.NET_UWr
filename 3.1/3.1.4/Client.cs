namespace _3._1._4
{
    class Client
    {
        public string Name { get; set; }

        public static void WakeUpBarber()
        {
            Program.customerEvent.Set();
        }
    }
}
