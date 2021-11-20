using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SASnapAnimWeights : StateAction
    {
        public bool ForceSample { get; set; }

        public SASnapAnimWeights()
        {
        }

        internal SASnapAnimWeights(BulkSerializeReader reader) : base(reader)
        {
            ForceSample = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ForceSample);
        }
    }
}
