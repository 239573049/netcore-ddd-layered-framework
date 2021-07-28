using CZGL.SystemInfo;
using CZGL.SystemInfo.Linux;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spider.Uitl.Util
{
    public class SystemUtil
    {
        private readonly  DynamicInfo info = new DynamicInfo();
        public  string GetCpuState()
        {
            return JsonConvert.SerializeObject(info.GetCpuState());
        }
        public  string GetTasks()
        {
            return JsonConvert.SerializeObject(info.GetTasks());
        }
        public  string GetPidInfo()
        {
            return JsonConvert.SerializeObject(info.GetPidInfo());
        }
        public  string GetMem()
        {
            return JsonConvert.SerializeObject(info.GetMem());
        }
        public static List<Data> GetSystemData()
        {
            var infos = NetworkInfo.GetNetworkInfos();
            var dataList = new List<Data>();
            foreach (var i in infos) {
                dataList.Add(new Data()
                {
                    AdapterName = i.Name,
                    NetworkLinkSpeed = $"{i.Speed / 1000 / 1000} Mbps\n",
                    AddressIpv6 = $"{i.AddressIpv6}",
                    AddressIpv4 = $"{i.AddressIpv4}",
                    DNS = $"{string.Join(',', i.DNSAddresses.Select(x => x.ToString()).ToArray())}",
                    Mac = i.Mac,
                    NetworkType = $"{i.NetworkType}",
                    ReceivedLength = $"{i.ReceivedLength / 1024 / 1024} MB",
                    SendLength = $"{i.SendLength / 1024 / 1024} MB",
                    Trademark = i.Trademark
                }) ;
            }
            return dataList;
        }
        public static List<InternetSpeed> InternetSpeed()
        {
            var info = NetworkInfo.GetNetworkInfos();
            var data = new List<InternetSpeed>();
            foreach (var i in info) {

                var tmp = i.GetInternetSpeed();
                data.Add(new InternetSpeed {Sent= $"{tmp.Sent.OriginSize / 1024} kb/s", Received= $"{tmp.Received.OriginSize / 1024} kb/s" });
            }
            return data;
        }
    }
    public class InternetSpeed
    {
        /// <summary>
        /// 网络上传速度
        /// </summary>
        public string Sent { get; set; }
        /// <summary>
        /// 网络下载速度
        /// </summary>
        public string Received { get; set; }
    }
    public class Data
    {
        /// <summary>
        /// 网卡名称
        /// </summary>
        public string AdapterName { get; set; }
        /// <summary>
        /// 网络链接速度
        /// </summary>
        public string NetworkLinkSpeed { get; set; }
        /// <summary>
        /// Ipv6
        /// </summary>
        public string AddressIpv6 { get; set; }
        /// <summary>
        /// Ipv4
        /// </summary>
        public string AddressIpv4 { get; set; }
        /// <summary>
        /// DNS
        /// </summary>
        public string DNS { get; set; }
        /// <summary>
        /// 上行流量统计
        /// </summary>
        public string SendLength { get; set; }
        /// <summary>
        /// 下行流量统计
        /// </summary>
        public string ReceivedLength { get; set; }
        /// <summary>
        /// 网络类型
        /// </summary>
        public string NetworkType { get; set; }
        /// <summary>
        /// 网卡MAC
        /// </summary>
        public string Mac { get; set; }
        /// <summary>
        /// 网卡信息
        /// </summary>
        public string Trademark { get; set; }
    }
}
