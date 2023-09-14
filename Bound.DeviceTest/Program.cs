// -------------------------------------------------------------------------------------------------
// Copyright (c) Bound Technologies AB. All rights reserved.
// -------------------------------------------------------------------------------------------------

using Bound;
using DeviceManager.Device.DeviceMethods;
using DeviceManager.Device.NewFolder;
using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Device
{
    public class Program
    {
        public static bool IsRunning = false;
        public static bool DeviceIsInUse = false;
        public static UserData UserData { get; set; }
        static string ChestMachine = "HostName=boundiothub.azure-devices.net;DeviceId=ChestMachine;SharedAccessKey=lfuuB5CoYDOVrMxmu0qwDEyzu+Qz3r6xL4VyEMEnaRs=";
        
        public static DeviceClient Client;

        public static void Main(string[] args)
        {

            Console.WriteLine("Device started");
            Client = DeviceClient.CreateFromConnectionString(ChestMachine, TransportType.Mqtt);

            Client.SetMethodHandlerAsync("start", StartMethod.OnStart, null).Wait();
            Client.SetMethodHandlerAsync("stop", StopMethod.OnStop, null).Wait();
            Console.ReadLine();

            Client.SetMethodHandlerAsync("start", null, null).Wait();
            Client.SetMethodHandlerAsync("stop", null, null).Wait();
            Client.CloseAsync().Wait();
        }
    }
}
