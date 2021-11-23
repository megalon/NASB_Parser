using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
	[Serializable]
    public class CTInputSeries : CheckThing
    {
        public int CheckFrames { get; set; }
        public List<LookForInput> InputSeries { get; set; } = new List<LookForInput>();
        public List<LookForInput> StopLooking { get; set; } = new List<LookForInput>();

        public CTInputSeries()
        {
        }

        internal CTInputSeries(BulkSerializeReader reader) : base(reader)
        {
            CheckFrames = reader.ReadInt();
            InputSeries = reader.ReadList(r => new LookForInput(r));
            StopLooking = reader.ReadList(r => new LookForInput(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CheckFrames);
            writer.Write(InputSeries);
            writer.Write(StopLooking);
        }
    }
}
