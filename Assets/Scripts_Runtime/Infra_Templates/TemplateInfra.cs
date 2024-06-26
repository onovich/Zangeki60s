using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Zangeki {

    public static class TemplateInfra {

        public static async Task LoadAssets(TemplateInfraContext ctx) {

            {
                var handle = Addressables.LoadAssetAsync<GameConfig>("TM_Config");
                var cotmfig = await handle.Task;
                ctx.Config_Set(cotmfig);
                ctx.configHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetsAsync<MapTM>("TM_Map", null);
                var mapList = await handle.Task;
                foreach (var tm in mapList) {
                    ctx.Map_Add(tm);
                }
                ctx.mapHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetsAsync<RoleTM>("TM_Role", null);
                var roleList = await handle.Task;
                foreach (var tm in roleList) {
                    ctx.Role_Add(tm);
                }
                ctx.roleHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetAsync<FrameVFXTM>("TM_FrameVFX");
                var tm = await handle.Task;
                ctx.FrameVFX_Set(tm);
                ctx.frameVFXHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetAsync<SoundTable>("Table_Sound");
                var soundTable = await handle.Task;
                ctx.SoundTable_Set(soundTable);
                ctx.soundTableHandle = handle;
            }

        }

        public static void Release(TemplateInfraContext ctx) {
            if (ctx.configHandle.IsValid()) {
                Addressables.Release(ctx.configHandle);
            }
            if (ctx.mapHandle.IsValid()) {
                Addressables.Release(ctx.mapHandle);
            }
            if (ctx.roleHandle.IsValid()) {
                Addressables.Release(ctx.roleHandle);
            }
            if (ctx.frameVFXHandle.IsValid()) {
                Addressables.Release(ctx.frameVFXHandle);
            }
            if (ctx.soundTableHandle.IsValid()) {
                Addressables.Release(ctx.soundTableHandle);
            }
        }

    }

}