using System;
using System.Net;
using SuperSocket.Common;
using SuperSocket.SocketBase;

namespace SurperSocket.Core.Service.AppBase
{
    /// <summary>
    /// IP过滤器
    /// </summary>
    public class IPConnectionFilter : IConnectionFilter
    {
        private Tuple<long, long>[] _mIpRanges;

        public bool Initialize(string name, IAppServer appServer)
        {
            Name = name;

            var ipRange = appServer.Config.Options.GetValue("ipRange");

            string[] ipRangeArray;

            if (string.IsNullOrEmpty(ipRange)
                || (ipRangeArray = ipRange.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)).Length <= 0)
            {
                throw new ArgumentException("The ipRange doesn't exist in configuration!");
            }

            _mIpRanges = new Tuple<long, long>[ipRangeArray.Length];

            for (int i = 0; i < ipRangeArray.Length; i++)
            {
                var range = ipRangeArray[i];
                _mIpRanges[i] = GenerateIpRange(range);
            }

            return true;
        }

        private Tuple<long, long> GenerateIpRange(string range)
        {
            var ipArray = range.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (ipArray.Length != 2)
                throw new ArgumentException("Invalid ipRange exist in configuration!");

            return new Tuple<long, long>(ConvertIpToLong(ipArray[0]), ConvertIpToLong(ipArray[1]));
        }

        private long ConvertIpToLong(string ip)
        {
            var points = ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (points.Length != 4)
                throw new ArgumentException("Invalid ipRange exist in configuration!");

            long value = 0;
            long unit = 1;

            for (int i = points.Length - 1; i >= 0; i--)
            {
                value += unit * points[i].ToInt32();
                unit *= 256;
            }

            return value;
        }

        public string Name { get; private set; }

        public bool AllowConnect(IPEndPoint remoteAddress)
        {
            var ip = remoteAddress.Address.ToString();
            var ipValue = ConvertIpToLong(ip);

            for (var i = 0; i < _mIpRanges.Length; i++)
            {
                var range = _mIpRanges[i];

                if (ipValue > range.Item2)
                    return false;

                if (ipValue < range.Item1)
                    return false;
            }

            return true;
        }
    }
}