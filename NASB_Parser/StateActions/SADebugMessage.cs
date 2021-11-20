using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SADebugMessage : StateAction
    {
        public string Message { get; set; }

        public SADebugMessage()
        {
        }

        public SADebugMessage(BulkSerializeReader reader) : base(reader)
        {
            Message = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Message);
        }
    }
}
