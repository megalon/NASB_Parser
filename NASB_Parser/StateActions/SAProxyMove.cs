using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAProxyMove : StateAction
    {
        public string MoveId { get; set; }

        public SAProxyMove()
        {
        }

        internal SAProxyMove(BulkSerializeReader reader) : base(reader)
        {
            MoveId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(MoveId);
        }
    }
}
