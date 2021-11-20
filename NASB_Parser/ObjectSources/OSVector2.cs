using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.ObjectSources
{
	[Serializable]
    public class OSVector2 : ObjectSource
    {
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public OSVector2()
        {
        }

        internal OSVector2(BulkSerializeReader reader) : base(reader)
        {
            X = FloatSource.Read(reader);
            Y = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(X);
            writer.Write(Y);
        }
    }
}
