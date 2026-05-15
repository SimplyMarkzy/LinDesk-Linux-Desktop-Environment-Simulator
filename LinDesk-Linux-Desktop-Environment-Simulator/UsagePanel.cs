using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class UsagePanel
    {
        public static DateTime Now { get; }
        public async Task Usage(Label CpuUsage, Label RamUsage, Label DiskUsage, Label NetUsage, Label LoadAvg, Label WorldTime, Label UpTime)
        {
            
            Random r = new Random();
            int CpuTick = 0;
            int DiskTick = 0;
            int SecondTick = 0;
            int MinuteTick = 0;
            int LastMinute = 0;
            int HourTick = 0;
            bool FTick = false;

            while (true)
            {
                await Task.Delay(1000);
                
                //Cpu
                int Cpu = r.Next(0, 100);
                CpuTick++;
                if (Cpu <= 20)
                {
                    CpuUsage.Content = "Cpu:  " + Cpu + "%";
                }
                else if (Cpu > 20 && CpuTick >= 60)
                {
                    CpuUsage.Content = "Cpu:  " + Cpu + "%";
                    CpuTick = 0;
                }
                else 
                {
                    
                }

                //Ram
                double Ram = Math.Round(4 + r.NextDouble() * (11 - 7), 1);
                RamUsage.Content = "Ram:  " + Ram + " / " + "32 " + "GB";

                //Disk
                int Disk = r.Next(0,100);
                DiskTick++;
                if (Disk <= 20)
                {
                    DiskUsage.Content = "Disk:  " + Disk + "%";
                }
                else if (Disk >= 20 && DiskTick >= 60)
                {
                    DiskUsage.Content = "Disk:  " + Disk + "%";
                    DiskTick = 0;
                }
                else 
                {

                }
               

                //Net
                double Netu = Math.Round(0 + r.NextDouble() * (30 - 0), 1);
                double Netd = Math.Round(0 + r.NextDouble() * (20 - 0), 1);
                NetUsage.Content = "Net:  " + Netd + " KB  / s ↓  " + Netu + "  KB / s ↑";

                //Time
                WorldTime.Content = DateTime.Now.ToString("HH:mm");

                //UpTime
                SecondTick++;
                if (SecondTick == 60)
                {
                    MinuteTick++;
                    SecondTick = 0;
                }
                if (MinuteTick == 60)
                {
                    HourTick++;
                    MinuteTick = 0;
                }
                UpTime.Content = "Uptime: " + HourTick.ToString("00") + ":" + MinuteTick.ToString("00") + ":" + SecondTick.ToString("00");

                //Load Average
                double Base = Math.Round(r.NextDouble() * 1.0, 2);
                double LML = Base;
                double LM5L = Math.Round(Base + (r.NextDouble() - 0.5) * 0.3, 2);
                double LM15L = Math.Round(Base + (r.NextDouble() - 0.5) * 0.5, 2);
                string LMLS = LML.ToString("0.00");
                string LM5LS = LM5L.ToString("0.00");
                string LM15LS = LM15L.ToString("0.00");
                if (FTick == false)
                {
                    LoadAvg.Content = "Load Average: " + LMLS + " " + LM5LS + " " + LM15LS;
                    FTick = true;
                }
                if (MinuteTick != LastMinute)
                {
                    LoadAvg.Content = "Load Average: " + LMLS + " " + LM5LS + " " + LM15LS;
                }

                LastMinute = MinuteTick;
            }
        }
    }
}
