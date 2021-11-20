using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SARefreshAttack : StateAction
    {
        public SARefreshAttack()
        {
        }

        internal SARefreshAttack(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
