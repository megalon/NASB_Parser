using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SASpawnFX : StateAction
    {
        public bool Dynamic { get; set; }
        public bool Track { get; set; }
        public bool BoneDir { get; set; }
        public string Id { get; set; }
        public string Bone { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 GlobalOffset { get; set; }
        public FloatSource DirX { get; set; }
        public FloatSource DirY { get; set; }
        public FloatSource DirZ { get; set; }
        public FloatSource DynamicX { get; set; }
        public FloatSource DynamicY { get; set; }
        public FloatSource DynamicZ { get; set; }
        public FloatSource Scale { get; set; }

        public SASpawnFX()
        {
        }

        internal SASpawnFX(BulkSerializeReader reader) : base(reader)
        {
            Dynamic = reader.ReadBool();
            Track = reader.ReadBool();
            BoneDir = reader.ReadBool();
            Id = reader.ReadString();
            Bone = reader.ReadString();
            LocalOffset = reader.ReadVector3();
            GlobalOffset = reader.ReadVector3();
            DirX = FloatSource.Read(reader);
            DirY = FloatSource.Read(reader);
            DirZ = FloatSource.Read(reader);
            DynamicX = FloatSource.Read(reader);
            DynamicY = FloatSource.Read(reader);
            DynamicZ = FloatSource.Read(reader);
            Scale = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Dynamic);
            writer.Write(Track);
            writer.Write(BoneDir);
            writer.Write(Id);
            writer.Write(Bone);
            writer.Write(LocalOffset);
            writer.Write(GlobalOffset);
            writer.Write(DirX);
            writer.Write(DirY);
            writer.Write(DirZ);
            writer.Write(DynamicX);
            writer.Write(DynamicY);
            writer.Write(DynamicZ);
            writer.Write(Scale);
        }
    }
}
