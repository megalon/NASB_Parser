using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAEndAttack : StateAction
    {
        public SAEndAttack()
        {
        }

        internal SAEndAttack(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
