using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAResetOnHits : StateAction
    {
        public SAResetOnHits()
        {
        }

        internal SAResetOnHits(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
