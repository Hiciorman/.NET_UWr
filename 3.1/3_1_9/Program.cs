using System.ServiceProcess;

namespace _3_1_9
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new MyNewService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
