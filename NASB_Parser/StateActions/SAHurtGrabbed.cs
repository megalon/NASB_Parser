using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAHurtGrabbed : StateAction
    {
        public string AtkProp { get; set; }

        public SAHurtGrabbed()
        {
        }

        internal SAHurtGrabbed(BulkSerializeReader reader) : base(reader)
        {
            AtkProp = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(AtkProp);
        }
    }
}
