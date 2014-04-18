using AppRemote.ServerClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppRemote.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //RemotingConfiguration.Configure("AppRemote.Client.exe.config");
            //RemotableType remoteObject = new RemotableType();
            //Console.WriteLine(remoteObject.SayHello());
            //Console.ReadLine();

            HttpChannel channel = null;
            int port = 9001;

            while (true)
            {
                try
                {
                    channel = new HttpChannel(port);
                    ChannelServices.RegisterChannel(channel, false);
                    break;
                }
                catch (SocketException)
                {
                    port++;
                    continue;
                }
            }

            string serverHostUrl = ConfigurationManager.AppSettings["ServerHostUrl"];

            object obj = Activator.GetObject(typeof(RemotableType), serverHostUrl);
            RemotableType remotableType = (RemotableType)obj;
            
            Console.WriteLine(remotableType.SayHello());

            CallbackType callback = new CallbackType();
            remotableType.RegisterCallback(callback);

            Console.ReadLine();
        }
    }
}
