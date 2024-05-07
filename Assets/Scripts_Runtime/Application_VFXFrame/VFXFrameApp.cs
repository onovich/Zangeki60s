using System;
using System.Threading.Tasks;
using Zangeki.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using MortiseFrame.Swing;

namespace Zangeki {
    public static class VFXFrameApp {

        public static void Init(VFXFrameAppContext ctx) {

        }

        public static void LateTick(VFXFrameAppContext ctx, float dt) {
            ctx.vfxFrameCore.Tick(dt);
        }

        public static int AddVFXToWorld(VFXFrameAppContext ctx,
                                         string vfxName,
                                         Sprite[] frames,
                                         bool isLoop,
                                         float frameInterval,
                                         Vector2 pos,
                                         string sortingLayer) {
            return ctx.vfxFrameCore.TrySpawnAndPlayVFX_ToWorldPos(vfxName,
                                                             frames,
                                                             isLoop,
                                                             frameInterval,
                                                             pos,
                                                             sortingLayerName: sortingLayer);
        }

        public static int AddVFXToTarget(VFXFrameAppContext ctx,
                                          string vfxName,
                                          Sprite[] frames,
                                          bool isLoop,
                                          float frameInterval,
                                          Transform target,
                                          string sortingLayer) {
            return ctx.vfxFrameCore.TrySpawnAndPlayVFX_ToTarget(vfxName,
                                                          frames,
                                                          isLoop,
                                                          frameInterval,
                                                          target,
                                                          Vector3.zero,
                                                          sortingLayerName: sortingLayer);
        }

        public static void FlipX(VFXFrameAppContext ctx, int preSpawnVFXID, bool flipX) {
            ctx.vfxFrameCore.FlipX(preSpawnVFXID, flipX);
        }

        public static void SetDelayEndSec(VFXFrameAppContext ctx, int preSpawnVFXID, float delayEndSec) {
            ctx.vfxFrameCore.SetDelayEndSec(preSpawnVFXID, delayEndSec);
        }

        public static void SetFadingOut(VFXFrameAppContext ctx, int preSpawnVFXID, float fadingOutSec, EasingType easingType, EasingMode easingMode) {
            ctx.vfxFrameCore.SetFadingOut(preSpawnVFXID, fadingOutSec, easingType, easingMode);
        }

        public static void PlayVFXManualy(VFXFrameAppContext ctx, int preSpawnVFXID) {
            ctx.vfxFrameCore.TryPlayManualy(preSpawnVFXID);
        }

        public static void StopVFXManualy(VFXFrameAppContext ctx, int preSpawnVFXID) {
            ctx.vfxFrameCore.TryStopManualy(preSpawnVFXID);
        }

        public static void TearDown(VFXFrameAppContext ctx) {
            ctx.vfxFrameCore.TearDown();
        }

        // Tap
        public static int VFX_PlayTapLeft(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.tap_left_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_TapLeft", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlayTapRight(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.tap_right_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_TapRight", frames, false, frameInterval, pos, layer);
        }

        // Clang_Break
        public static int VFX_PlayClangBreak1(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.clang_break1_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_ClangBreak1", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlayClangBreak2(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.clang_break2_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_ClangBreak2", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlayClangBreak3(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.clang_break3_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_ClangBreak3", frames, false, frameInterval, pos, layer);
        }

        // Swoosh
        public static int VFX_PlaySwooshLeft(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.swoosh_left_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_SwooshLeft", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlaySwooshRight(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.swoosh_right_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_SwooshRight", frames, false, frameInterval, pos, layer);
        }

        // Swoosh_Break
        public static int VFX_PlaySwooshBreak1(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.swoosh_break1_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_SwooshBreak1", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlaySwooshBreak2(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.swoosh_break2_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_SwooshBreak2", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlaySwooshBreak3(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.swoosh_break3_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_SwooshBreak3", frames, false, frameInterval, pos, layer);
        }

        // Slash
        public static int VFX_PlaySlashLeft(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.slash_left_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_SlashLeft", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlaySlashRight(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.slash_right_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_SlashRight", frames, false, frameInterval, pos, layer);
        }

        // Blade
        public static int VFX_PlayBlade1(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.blade1_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_Blade1", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlayBlade2(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.blade2_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_Blade2", frames, false, frameInterval, pos, layer);
        }

        public static int VFX_PlayBlade3(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.blade3_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "VFX_Blade3", frames, false, frameInterval, pos, layer);
        }

        // Blood
        public static int VFX_PlayBlood(GameBusinessContext ctx, Vector2 pos) {
            if (!ctx.currentMapEntity.isBlind) return -1;
            var table = ctx.templateInfraContext.FrameVFX_Get();
            var frames = table.blood1_frame;
            var frameInterval = table.intervalTime;
            var layer = SortingLayerConst.VFX;
            return VFXFrameApp.AddVFXToWorld(ctx.vfxFrameContext, "Blood", frames, false, frameInterval, pos, layer);
        }

    }

}