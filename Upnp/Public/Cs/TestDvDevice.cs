using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Zapp.Core;
using Zapp.ControlPoint;
using Zapp.Device;

namespace Zapp.Device
{
    class Program
    {
        public static void Main(string[] args)
        {
            InitParams initParams = new InitParams
            {
                MsearchTimeSecs = 1,
                UseLoopbackNetworkInterface = true
            };
            Library lib = new Library();
            lib.Initialise(initParams);
            lib.StartCombined();
            new Runner();
            lib.Close();
        }
    }

    class Runner
    {
        private List<CpDevice> iDeviceList;

        public Runner()
        {
            Console.Write("TestDvDeviceCs - starting\n");

            DeviceBasic device = new DeviceBasic();
            iDeviceList = new List<CpDevice>();
            CpDeviceList.ChangeHandler added = new CpDeviceList.ChangeHandler(DeviceAdded);
            CpDeviceList.ChangeHandler removed = new CpDeviceList.ChangeHandler(DeviceRemoved);
            CpDeviceListUpnpServiceType list = new CpDeviceListUpnpServiceType("zapp.org", "TestBasic", 1, added, removed);
            Semaphore sem = new Semaphore(0, 1);
            sem.WaitOne(1000);
            Debug.Assert(iDeviceList.Count == 1);
            TestBasicCp cp = new TestBasicCp(iDeviceList[0]);
            cp.TestActions();
	        cp.TestSubscriptions();
            list.Dispose();
            lock (this)
            {
                for (int i = 0; i < iDeviceList.Count; i++)
                {
                    iDeviceList[i].RemoveRef();
                }
            }
            device.Dispose();

            Console.Write("TestDvDeviceCs - completed\n");
        }

        private void DeviceAdded(CpDeviceList aList, CpDevice aDevice)
        {
            lock (this)
            {
                if (aDevice.Udn() == DeviceBasic.gDeviceName)
                {
                    aDevice.AddRef();
                    iDeviceList.Add(aDevice);
                }
            }
        }

        private void DeviceRemoved(CpDeviceList aList, CpDevice aDevice)
        {
            lock (this)
            {
                string udn = aDevice.Udn();
                int count = iDeviceList.Count;
                for (int i = 0; i < count; i++)
                {
                    if (iDeviceList[i].Udn() == udn)
                    {
                        iDeviceList.RemoveAt(i);
                        iDeviceList[i].RemoveRef();
                    }
                }
            }
        }
    }
}
