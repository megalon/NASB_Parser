using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public abstract class FloatSource : ISerializable
    {
        public TypeId TID { get; private set; }
        public int Version { get; private set; }

        public FloatSource()
        {
        }

        internal FloatSource(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static FloatSource Read(BulkSerializeReader reader)
        {
            FloatSource floatSource = null;
            switch ((TypeId)reader.PeekInt())
            {
                case TypeId.AgentId: floatSource = new FSAgent(reader); break;
                case TypeId.BonesId: floatSource = new FSBones(reader); break;
                case TypeId.AttackId: floatSource = new FSAttack(reader); break;
                case TypeId.FrameId: floatSource = new FSFrame(reader); break;
                case TypeId.InputId: floatSource = new FSInput(reader); break;
                case TypeId.FuncId: floatSource = new FSFunc(reader); break;
                case TypeId.MovementId: floatSource = new FSMovement(reader); break;
                case TypeId.CombatId: floatSource = new FSCombat(reader); break;
                case TypeId.GrabsId: floatSource = new FSGrabs(reader); break;
                case TypeId.DataId: floatSource = new FSData(reader); break;
                case TypeId.ScratchId: floatSource = new FSScratch(reader); break;
                case TypeId.AnimId: floatSource = new FSAnim(reader); break;
                case TypeId.SpeedId: floatSource = new FSSpeed(reader); break;
                case TypeId.PhysicsId: floatSource = new FSPhysics(reader); break;
                case TypeId.CollisionId: floatSource = new FSCollision(reader); break;
                case TypeId.TimerId: floatSource = new FSTimer(reader); break;
                case TypeId.LagId: floatSource = new FSLag(reader); break;
                case TypeId.EffectsId: floatSource = new FSEffects(reader); break;
                case TypeId.ColorsId: floatSource = new FSColors(reader); break;
                case TypeId.OnHitId: floatSource = new FSOnHit(reader); break;
                case TypeId.RandomId: floatSource = new FSRandom(reader); break;
                case TypeId.CameraId: floatSource = new FSCameraInfo(reader); break;
                case TypeId.SportsId: floatSource = new FSSports(reader); break;
                case TypeId.Vector2Mag: floatSource = new FSVector2Mag(reader); break;
                case TypeId.CPUHelpId: floatSource = new FSCpuHelp(reader); break;
                case TypeId.ItemId: floatSource = new FSItem(reader); break;
                case TypeId.ModeId: floatSource = new FSMode(reader); break;
                case TypeId.JumpsId: floatSource = new FSJumps(reader); break;
                case TypeId.RootAnimId: floatSource = new FSRootAnim(reader); break;
                case TypeId.FloatId: floatSource = new FSValue(reader); break;
                default:  throw new ReadException(reader, $"Could not parse valid {nameof(FloatSource)} type from: {reader.PeekInt()}!");
            }
            return floatSource;
        }

        public enum TypeId
        {
            FloatId,
            AgentId,
            BonesId,
            AttackId,
            FrameId,
            InputId,
            FuncId,
            MovementId,
            CombatId,
            GrabsId,
            DataId,
            ScratchId,
            AnimId,
            SpeedId,
            PhysicsId,
            CollisionId,
            TimerId,
            LagId,
            EffectsId,
            ColorsId,
            OnHitId,
            RandomId,
            CameraId,
            SportsId,
            Vector2Mag,
            CPUHelpId,
            ItemId,
            ModeId,
            JumpsId,
            RootAnimId
        }
    }
}