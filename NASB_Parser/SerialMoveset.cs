using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
	[Serializable]
    public class SerialMoveset : ISerializable
    {
        public List<IdState> States { get; private set; } = new List<IdState>();

        public SerialMoveset()
        {
        }

        public SerialMoveset(BulkSerializeReader reader)
        {
            reader.Reset();
            _ = reader.ReadInt();
            States = reader.ReadList(r => new IdState(r));
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(States);
        }
    }
}
