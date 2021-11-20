using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public enum HurtType
    {
        Normal,
        Invincible,
        Intangible,
        Block,
        GrabbedOnly
    }
}
