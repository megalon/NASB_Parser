using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAForceExtraInputCheck : StateAction
    {
        public SAForceExtraInputCheck()
        {
        }

        internal SAForceExtraInputCheck(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
