using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.ObjectSources
{
	[Serializable]
    public class ObjectSource : ISerializable
    {
        public TypeId TID { get; set; }
        public int Version { get; set; }

        public ObjectSource()
        {
        }

        internal ObjectSource(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static ObjectSource Read(BulkSerializeReader reader)
        {
            ObjectSource objectSource = null;
            switch ((TypeId)reader.PeekInt())
            {
                case TypeId.FloatId: objectSource = new OSFloat(reader); break;
                case TypeId.Vector2Id: objectSource = new OSVector2(reader); break;
                case TypeId.BaseIdentifier: objectSource = new ObjectSource(reader); break;
                default: throw new ReadException(reader, $"Could not parse valid {nameof(ObjectSource)} type from: {reader.PeekInt()}!");
            }
            return objectSource;
        }

        public enum TypeId
        {
            BaseIdentifier,
            FloatId,
            Vector2Id
        }
    }
}
