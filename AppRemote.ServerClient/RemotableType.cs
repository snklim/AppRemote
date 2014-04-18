using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppRemote.ServerClient
{
    public class RemotableType : MarshalByRefObject
    {
        public string SayHello()
        {
            Console.WriteLine("RemotableType.SayHello() was called!");
            return "Hello, world";
        }

        List<CallbackType> _callbacks = new List<CallbackType>();

        public void RegisterCallback(CallbackType callback)
        {
            _callbacks.Add(callback);

            new Thread(() =>
            {
                Thread.Sleep(2000);

                foreach (CallbackType cb in _callbacks)
                {
                    cb.SayStatus("new connection");
                }

            }).Start();
        }
    }
}
