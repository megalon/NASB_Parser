using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
	[Serializable]
    public class Jump : ISerializable
    {
        public TypeId TID { get; set; }
        public int Version { get; set; }

        public Jump()
        {
        }

        internal Jump(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        internal static Jump Read(BulkSerializeReader reader)
        {
            Jump jump = null;
            switch ((TypeId)reader.PeekInt())
            {
                case TypeId.HeightId: jump = new HeightJump(reader); break;
                case TypeId.HoldId: jump = new HoldJump(reader); break;
                case TypeId.AirdashId: jump = new AirDashJump(reader); break;
                case TypeId.KnockbackId: jump = new KnockbackJump(reader); break;
                case TypeId.DelayedId: jump = new DelayedJump(reader); break;
                case TypeId.KnockbackAltId: jump = new KnockbackAltJump(reader); break;
                case TypeId.BaseIdentifier: jump = new Jump(reader); break;
                // This is more aggressive than the game parser for better error detection.
                default: throw new ReadException(reader, $"Could not parse valid {nameof(Jump)} type from: {reader.PeekInt()}!");
            }
            return jump;
        }

        public enum TypeId
        {
            BaseIdentifier,
            HeightId,
            HoldId,
            AirdashId,
            KnockbackId,
            DelayedId,
            KnockbackAltId
        }
    }
}
