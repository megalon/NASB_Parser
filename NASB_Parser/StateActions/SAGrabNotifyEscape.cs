using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAGrabNotifyEscape : StateAction
    {
        public SAGrabNotifyEscape()
        {
        }

        internal SAGrabNotifyEscape(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
