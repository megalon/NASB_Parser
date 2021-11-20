using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAAddInputEventFromFrame : StateAction
    {
        public GIEV AddEvent { get; set; }

        public SAAddInputEventFromFrame()
        {
        }

        internal SAAddInputEventFromFrame(BulkSerializeReader reader) : base(reader)
        {
            AddEvent = (GIEV)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(AddEvent);
        }
    }
}
