using System;
using System.Collections.Generic;
using System.Text;
using TestClientInterfaces;

namespace WcfHttpTestService
{
    public class Service: IWcfHttpTestService
    {
        public string GetMeldung()
        {
            return "Hello World";
        }
    }
}
