using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pvmsentity.layer
{
    public class entitylog
    {
        public DateTime login//login time
        { get; set; }
        public string userid//userid
        { get; set; }
        public DateTime applypassport//apply passport time
        { get; set; }
        public DateTime userreg//register time
        { get; set; }
        public DateTime applyvisa//apply visa time
        { get; set; }
        public DateTime passrenew//passport renew time
        { get; set; }
        public DateTime cancelvisa//cancel  visa time
        { get; set; }
        public DateTime logout//logout time
        { get; set; }
        public string activity//activity string 
        { get; set; }
        public StringBuilder sb=new StringBuilder();
        public string ip//ip address string 
        { get; set; }
        public string server//server address string
        { get; set; }

    }
}
