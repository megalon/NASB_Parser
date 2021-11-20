using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAUpdateHurtboxes : StateAction
    {
        public SAUpdateHurtboxes()
        {
        }

        internal SAUpdateHurtboxes(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
