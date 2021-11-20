using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SADeactivateInputAction : StateAction
    {
        public string Id { get; set; }

        public SADeactivateInputAction()
        {
        }

        internal SADeactivateInputAction(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Id);
        }
    }
}
