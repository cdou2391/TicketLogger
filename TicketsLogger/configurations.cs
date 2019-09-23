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

        internal string _StringValue;
        public string StringValue
        {
            get { return _StringValue; }
            set { _StringValue = value; }
        }
    }
}
