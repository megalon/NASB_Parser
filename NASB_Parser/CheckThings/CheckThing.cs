using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
	[Serializable]
    public class CheckThing : ISerializable
    {
        public TypeId TID { get; private set; }
        public int Version { get; private set; }

        public CheckThing()
        {
        }

        internal CheckThing(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static CheckThing Read(BulkSerializeReader reader)
        {
            CheckThing thing = null;
            switch ((TypeId)reader.PeekInt())
            {
                case TypeId.MultipleId: thing = new CTMultiple(reader); break;
                case TypeId.CompareId: thing = new CTCompareFloat(reader); break;
                case TypeId.DoubleTapId: thing = new CTDoubleTapId(reader); break;
                case TypeId.InputId: thing = new CTInput(reader); break;
                case TypeId.InputSeriesId: thing = new CTInputSeries(reader); break;
                case TypeId.TechId: thing = new CTCheckTech(reader); break;
                case TypeId.GrabId: thing = new CTGrabId(reader); break;
                case TypeId.GrabAgentId: thing = new CTGrabbedAgent(reader); break;
                case TypeId.SkinId: thing = new CTSkin(reader); break;
                case TypeId.MoveId: thing = new CTMove(reader); break;
                case TypeId.BaseIdentifier: thing = new CheckThing(reader); break;
                default: throw new ReadException(reader, $"Could not parse valid {nameof(CheckThing)} type from: {reader.PeekInt()}!");
            }
            return thing;
        }

        public enum TypeId
        {
            BaseIdentifier,
            MultipleId,
            CompareId,
            DoubleTapId,
            InputId,
            InputSeriesId,
            TechId,
            GrabId,
            GrabAgentId,
            SkinId,
            MoveId
        }

        public enum CheckWay
        {
            Equal,
            NotEqual,
            Less,
            Larger,
            EOLess,
            EOLarger
        }
    }
}
