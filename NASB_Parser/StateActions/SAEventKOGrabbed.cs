using System;
using System.Collections.Generic;
using System.Text;
using static NASB_Parser.StateActions.SAEventKO;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAEventKOGrabbed : StateAction
    {
        public KOType KO { get; set; }

        public SAEventKOGrabbed()
        {
        }

        internal SAEventKOGrabbed(BulkSerializeReader reader) : base(reader)
        {
            KO = (KOType)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(KO);
        }
    }
}
