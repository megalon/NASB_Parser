using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SASetCommandGrab : StateAction
    {
        public string State { get; set; }

        public SASetCommandGrab()
        {
        }

        internal SASetCommandGrab(BulkSerializeReader reader) : base(reader)
        {
            State = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(State);
        }
    }
}
