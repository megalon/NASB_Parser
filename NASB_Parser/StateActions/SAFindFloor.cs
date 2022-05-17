using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAFindFloor : StateAction
    {
        public float SeekRange { get; set; }
        public FloatSource Range { get; set; }

        public SAFindFloor()
        { }

        internal SAFindFloor(BulkSerializeReader reader) : base(reader)
        {
            if (Version < 1)
            {
                SeekRange = reader.ReadFloat();
                Range = new FSValue(SeekRange);
            }
            else
            {
                Range = FloatSource.Read(reader);
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Range);
        }
    }
}
