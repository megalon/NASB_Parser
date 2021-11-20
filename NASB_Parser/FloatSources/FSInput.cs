using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
	[Serializable]
    public class FSInput : FloatSource
    {
        public CheckInput Input { get; set; }

        public FSInput()
        {
        }

        internal FSInput(BulkSerializeReader reader) : base(reader)
        {
            Input = (CheckInput)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Input);
        }

        public enum CheckInput
        {
            CtrlX,
            CtrlXRaw,
            CtrlY,
            Attack,
            Strong,
            Special,
            Jump,
            Defend,
            Fun,
            Grabmacro
        }
    }
}
