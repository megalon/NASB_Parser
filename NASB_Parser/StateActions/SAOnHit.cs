using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAOnHit : StateAction
    {
        public bool Hitbox { get; set; }
        public int Box { get; set; }
        public StateAction Action { get; set; }

        public SAOnHit()
        {
        }

        internal SAOnHit(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadBool();
            Box = reader.ReadInt();
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Hitbox);
            writer.Write(Box);
            writer.Write(Action);
        }
    }
}
