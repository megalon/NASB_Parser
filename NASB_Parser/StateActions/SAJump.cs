using NASB_Parser.Jumps;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAJump : StateAction
    {
        public string JumpId { get; set; }
        public Jump Jump { get; set; }

        public SAJump()
        {
        }

        internal SAJump(BulkSerializeReader reader) : base(reader)
        {
            JumpId = reader.ReadString();
            Jump = Jump.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(JumpId);
            writer.Write(Jump);
        }
    }
}
