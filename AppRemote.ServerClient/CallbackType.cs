﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRemote.ServerClient
{
    public class CallbackType : MarshalByRefObject
    {
        public void SayStatus(Record status)
        {
            Console.WriteLine(status.Type);
        }
    }
}
