using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAIgnoreGrabbed : StateAction
    {
        public SAIgnoreGrabbed()
        {
        }

        internal SAIgnoreGrabbed(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
