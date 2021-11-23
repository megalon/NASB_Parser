using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class StateAction : ISerializable
    {
        public TypeId TID { get; set; }
        public int Version { get; set; }

        public StateAction()
        {
        }

        protected StateAction(BulkSerializeReader reader)
        {
            // Reads past two ints
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static StateAction Read(BulkSerializeReader reader)
        {
            StateAction stateAction = null;
            switch ((TypeId)reader.PeekInt())
            {
                case TypeId.DebugId: stateAction = new SADebugMessage(reader); break;
                case TypeId.PlayAnimId: stateAction = new SAPlayAnim(reader); break;
                case TypeId.RootAnimId: stateAction = new SAPlayRootAnim(reader); break;
                case TypeId.SnapAnimWeightsId: stateAction = new SASnapAnimWeights(reader); break;
                case TypeId.StandardInputId: stateAction = new SAStandardInput(reader); break;
                case TypeId.InputId: stateAction = new SAInputAction(reader); break;
                case TypeId.DeactInputId: stateAction = new SADeactivateInputAction(reader); break;
                case TypeId.InputEventFromFrameId: stateAction = new SAAddInputEventFromFrame(reader); break;
                case TypeId.CancelStateId: stateAction = new SACancelToState(reader); break;
                case TypeId.CustomCallId: stateAction = new SACustomCall(reader); break;
                case TypeId.TimerId: stateAction = new SATimedAction(reader); break;
                case TypeId.OrderId: stateAction = new SAOrderedSensitive(reader); break;
                case TypeId.ProxyId: stateAction = new SAProxyMove(reader); break;
                case TypeId.CheckId: stateAction = new SACheckThing(reader); break;
                case TypeId.ActiveActionId: stateAction = new SAActiveAction(reader); break;
                case TypeId.DeactivateActionId: stateAction = new SADeactivateAction(reader); break;
                case TypeId.SetFloatId: stateAction = new SASetFloatTarget(reader); break;
                case TypeId.OnBounceId: stateAction = new SAOnBounce(reader); break;
                case TypeId.OnLeaveEdgeId: stateAction = new SAOnLeaveEdge(reader); break;
                case TypeId.OnStoppedAtEdgeId: stateAction = new SAOnStoppedAtLedge(reader); break;
                case TypeId.OnLandId: stateAction = new SAOnLand(reader); break;
                case TypeId.OnCancelId: stateAction = new SAOnCancel(reader); break;
                case TypeId.RefreshAtkId: stateAction = new SARefreshAttack(reader); break;
                case TypeId.EndAtkId: stateAction = new SAEndAttack(reader); break;
                case TypeId.SetHitboxCountId: stateAction = new SASetHitboxCount(reader); break;
                case TypeId.ConfigHitboxId: stateAction = new SAConfigHitbox(reader); break;
                case TypeId.SetAtkPropId: stateAction = new SASetAttackProp(reader); break;
                case TypeId.ManipHitboxId: stateAction = new SAManipHitbox(reader); break;
                case TypeId.UpdateHurtsetId: stateAction = new SAUpdateHurtboxes(reader); break;
                case TypeId.SetupHurtsetId: stateAction = new SASetupHurtboxes(reader); break;
                case TypeId.ManipHurtboxId: stateAction = new SAManipHurtbox(reader); break;
                case TypeId.BoneStateId: stateAction = new SABoneState(reader); break;
                case TypeId.BoneScaleId: stateAction = new SABoneScale(reader); break;
                case TypeId.SpawnAgentId: stateAction = new SASpawnAgent(reader); break;
                case TypeId.LocalFXId: stateAction = new SALocalFX(reader); break;
                case TypeId.SpawnFXId: stateAction = new SASpawnFX(reader); break;
                case TypeId.HitboxFXId: stateAction = new SASetHitboxFX(reader); break;
                case TypeId.SFXId: stateAction = new SAPlaySFX(reader); break;
                case TypeId.HitboxSFXId: stateAction = new SASetHitboxSFX(reader); break;
                case TypeId.ColorTintId: stateAction = new SAColorTint(reader); break;
                case TypeId.FindFloorId: stateAction = new SAFindFloor(reader); break;
                case TypeId.HurtGrabbedId: stateAction = new SAHurtGrabbed(reader); break;
                case TypeId.LaunchGrabbedId: stateAction = new SALaunchGrabbed(reader); break;
                case TypeId.StateCancelGrabbedId: stateAction = new SAStateCancelGrabbed(reader); break;
                case TypeId.EndGrabId: stateAction = new SAEndGrab(reader); break;
                case TypeId.GrabNotifyEscapeId: stateAction = new SAGrabNotifyEscape(reader); break;
                case TypeId.IgnoreGrabbedId: stateAction = new SAIgnoreGrabbed(reader); break;
                case TypeId.EventKOId: stateAction = new SAEventKO(reader); break;
                case TypeId.EventKOGrabbedId: stateAction = new SAEventKOGrabbed(reader); break;
                case TypeId.CameraShakeId: stateAction = new SACameraShake(reader); break;
                case TypeId.ResetOnHitId: stateAction = new SAResetOnHits(reader); break;
                case TypeId.OnHitId: stateAction = new SAOnHit(reader); break;
                case TypeId.FastForwardId: stateAction = new SAFastForwardState(reader); break;
                case TypeId.TimingTweakId: stateAction = new SATimingTweak(reader); break;
                case TypeId.MapAnimId: stateAction = new SAMapAnimation(reader); break;
                case TypeId.AlterMoveDtId: stateAction = new SAAlterMoveDT(reader); break;
                case TypeId.AlterMoveVelId: stateAction = new SAAlterMoveVel(reader); break;
                case TypeId.SetStagePartId: stateAction = new SASetStagePart(reader); break;
                case TypeId.SetStagePartsDefaultId: stateAction = new SASetStagePartsDefault(reader); break;
                case TypeId.JumpId: stateAction = new SAJump(reader); break;
                case TypeId.StopJumpId: stateAction = new SAStopJump(reader); break;
                case TypeId.ManageAirJumpId: stateAction = new SAManageAirJump(reader); break;
                case TypeId.LeaveGroundId: stateAction = new SALeaveGround(reader); break;
                case TypeId.UnhogEdgeId: stateAction = new SAUnHogEdge(reader); break;
                case TypeId.SFXTimelineId: stateAction = new SAPlaySFXTimeline(reader); break;
                case TypeId.FindLastHorizontalInputId: stateAction = new SAFindLastHorizontalInput(reader); break;
                case TypeId.SetCommandGrab: stateAction = new SASetCommandGrab(reader); break;
                case TypeId.CameraPunchId: stateAction = new SACameraPunch(reader); break;
                case TypeId.SpawnAgent2Id: stateAction = new SASpawnAgent2(reader); break;
                case TypeId.ManipDecorChainId: stateAction = new SAManipDecorChain(reader); break;
                case TypeId.UpdateHitboxesId: stateAction = new SAUpdateHitboxes(reader); break;
                case TypeId.SampleAnimId: stateAction = new SASampleAnim(reader); break;
                case TypeId.ForceExtraInputId: stateAction = new SAForceExtraInputCheck(reader); break;
                case TypeId.LaunchGrabbedCustomId: stateAction = new SALaunchGrabbedCustom(reader); break;
                case TypeId.BaseIdentifier: stateAction = new StateAction(reader); break;
                default:  throw new ReadException(reader, $"Could not parse valid {nameof(StateAction)} type from: {reader.PeekInt()}!");
            }
            return stateAction;
    }

        public enum TypeId
        {
            BaseIdentifier,
            DebugId,
            PlayAnimId,
            RootAnimId,
            SnapAnimWeightsId,
            StandardInputId,
            InputId,
            DeactInputId,
            InputEventFromFrameId,
            CancelStateId,
            CustomCallId,
            TimerId,
            OrderId,
            ProxyId,
            CheckId,
            ActiveActionId,
            DeactivateActionId,
            SetFloatId,
            OnBounceId,
            OnLeaveEdgeId,
            OnStoppedAtEdgeId,
            OnLandId,
            OnCancelId,
            RefreshAtkId,
            EndAtkId,
            SetHitboxCountId,
            ConfigHitboxId,
            SetAtkPropId,
            ManipHitboxId,
            UpdateHurtsetId,
            SetupHurtsetId,
            ManipHurtboxId,
            BoneStateId,
            BoneScaleId,
            SpawnAgentId,
            LocalFXId,
            SpawnFXId,
            HitboxFXId,
            SFXId,
            HitboxSFXId,
            ColorTintId,
            FindFloorId,
            HurtGrabbedId,
            LaunchGrabbedId,
            StateCancelGrabbedId,
            EndGrabId,
            GrabNotifyEscapeId,
            IgnoreGrabbedId,
            EventKOId,
            EventKOGrabbedId,
            CameraShakeId,
            ResetOnHitId,
            OnHitId,
            FastForwardId,
            TimingTweakId,
            MapAnimId,
            AlterMoveDtId,
            AlterMoveVelId,
            SetStagePartId,
            SetStagePartsDefaultId,
            JumpId,
            StopJumpId,
            ManageAirJumpId,
            LeaveGroundId,
            UnhogEdgeId,
            SFXTimelineId,
            FindLastHorizontalInputId,
            SetCommandGrab,
            CameraPunchId,
            SpawnAgent2Id,
            ManipDecorChainId,
            UpdateHitboxesId,
            SampleAnimId,
            ForceExtraInputId,
            LaunchGrabbedCustomId
        }
    }
}
