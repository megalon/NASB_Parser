using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAUpdateHitboxes : StateAction
    {
        public SAUpdateHitboxes()
        {
        }

        internal SAUpdateHitboxes(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
