using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
	[Serializable]
    public class FSEffects : FloatSource
    {
        public string LocalFxId { get; set; }
        public ManipAspect Masp { get; set; }

        public FSEffects()
        {
        }

        internal FSEffects(BulkSerializeReader reader) : base(reader)
        {
            LocalFxId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(LocalFxId);
        }

        public enum ManipAspect
        {
            TimeElapsed,
            Length,
            AddToElapsed
        }
    }
}
