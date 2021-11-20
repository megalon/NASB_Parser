using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAManipHitbox : StateAction
    {
        public List<HBM> Manips { get; private set; } = new List<HBM>();

        public SAManipHitbox()
        {
        }

        internal SAManipHitbox(BulkSerializeReader reader) : base(reader)
        {
            Manips = reader.ReadList(r => new HBM(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Manips);
        }

        public enum Manip
        {
            Radius,
            InteractWithHurtsets,
            WorldOffsetX,
            WorldOffsetY,
            WorldOffsetZ,
            LocalOffsetX,
            LocalOffsetY,
            LocalOffsetZ,
            WorldOffsetX2nd,
            WorldOffsetY2nd,
            WorldOffsetZ2nd,
            LocalOffsetX2nd,
            LocalOffsetY2nd,
            LocalOffsetZ2nd
        }

        [Serializable]
        public class HBM : ISerializable
        {
            public Manip Manip { get; set; }
            public int Hitbox { get; set; }
            public FloatSource Source { get; set; }

            public HBM()
            {
            }

            internal HBM(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                Manip = (Manip)reader.ReadInt();
                Hitbox = reader.ReadInt();
                Source = FloatSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(Manip);
                writer.Write(Hitbox);
                writer.Write(Source);
            }
        }
    }
}
