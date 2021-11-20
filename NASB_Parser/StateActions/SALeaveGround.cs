using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SALeaveGround : StateAction
    {
        public SALeaveGround()
        {
        }

        internal SALeaveGround(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
