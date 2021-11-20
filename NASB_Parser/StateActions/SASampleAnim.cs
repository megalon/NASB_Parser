using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SASampleAnim : StateAction
    {
        public SASampleAnim()
        {
        }

        internal SASampleAnim(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}
