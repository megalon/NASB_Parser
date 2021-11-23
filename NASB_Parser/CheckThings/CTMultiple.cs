using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
	[Serializable]
    public class CTMultiple : CheckThing
    {
        public CheckMatch Match { get; set; } = CheckMatch.All;
        public List<CheckThing> Checklist { get; set; } = new List<CheckThing>();

        public CTMultiple()
        {
        }

        internal CTMultiple(BulkSerializeReader reader) : base(reader)
        {
            Match = (CheckMatch)reader.ReadInt();
            Checklist = reader.ReadList(r => Read(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Match);
            writer.Write(Checklist);
        }

        public enum CheckMatch
        {
            Any,
            All,
            One,
            None
        }
    }
}
