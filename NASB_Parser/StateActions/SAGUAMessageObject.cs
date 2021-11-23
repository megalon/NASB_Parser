using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.ObjectSources;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAGUAMessageObject : ISerializable
    {
        public string PlainMessage { get; set; }
        public List<MessageDynamic> Dynamics { get; set; } = new List<MessageDynamic>();

        public SAGUAMessageObject()
        {
        }

        internal SAGUAMessageObject(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            PlainMessage = reader.ReadString();
            Dynamics = reader.ReadList(r => new MessageDynamic(r));
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(PlainMessage);
            writer.Write(Dynamics);
        }

        [Serializable]
        public class MessageDynamic : ISerializable
        {
            public string Id { get; set; }
            public ObjectSource ObjectSource { get; set; }

            public MessageDynamic()
            {
            }

            internal MessageDynamic(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                Id = reader.ReadString();
                ObjectSource = ObjectSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(Id);
                writer.Write(ObjectSource);
            }
        }
    }
}
