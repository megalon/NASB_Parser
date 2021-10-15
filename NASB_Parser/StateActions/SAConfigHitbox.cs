﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAConfigHitbox : StateAction
    {
        public int Hitbox { get; set; }
        public bool ForceZ0 { get; set; }
        public float Radius { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public string Prop { get; set; }
        public string Bone { get; set; }
        public string FxId { get; set; }
        public string SfxId { get; set; }
        public bool SecondTrack { get; set; }
        public string Bone2 { get; set; }
        public Vector3 LocalOffset2 { get; set; }
        public Vector3 WorldOffset2 { get; set; }

        public SAConfigHitbox()
        {
        }

        internal SAConfigHitbox(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            bool hasSecondTrackData = reader.ReadInt() != 0;
            Hitbox = reader.ReadInt();
            ForceZ0 = reader.ReadBool();
            Radius = reader.ReadFloat();
            LocalOffset = reader.ReadVector3();
            WorldOffset = reader.ReadVector3();
            Prop = reader.ReadString();
            Bone = reader.ReadString();
            FxId = reader.ReadString();
            SfxId = reader.ReadString();
            if (hasSecondTrackData)
            {
                SecondTrack = reader.ReadBool();
                if (SecondTrack)
                {
                    Bone2 = reader.ReadString();
                    LocalOffset2 = reader.ReadVector3();
                    WorldOffset2 = reader.ReadVector3();
                }
            }
        }
    }
}