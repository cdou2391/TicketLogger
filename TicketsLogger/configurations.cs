using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TicketsLogger
{
    
    class configurations
    {
        
        internal int _ListIndex;
        public int ListIndex
        {
            get { return _ListIndex; }
            set { _ListIndex = value; }
        }

        internal bool _TrueFalse;
        public bool TrueFalse
        {
            get { return _TrueFalse; }
            set { _TrueFalse = value; }
        }

        internal string _Email;
        internal string _Password;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
    }
}
