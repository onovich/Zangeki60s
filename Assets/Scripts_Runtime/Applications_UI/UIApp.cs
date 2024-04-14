using System;
using System.Threading.Tasks;
using Zangeki.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Zangeki {
    public static class UIApp {

        public static void Init(UIAppContext ctx) {

        }

        public static async Task LoadAssets(UIAppContext ctx) {
            try {
                await ctx.uiCore.LoadAssets();
            } catch (Exception e) {
                GLog.LogError(e.ToString());
            }
        }

        // Tick
        public static void LateTick(UIAppContext ctx, float dt) {
            ctx.uiCore.LateTick(dt);
        }

        // Panel - Login
        public static void Login_Open(UIAppContext ctx) {
            PanelLoginDomain.Open(ctx);
        }

        public static void Login_Close(UIAppContext ctx) {
            PanelLoginDomain.Close(ctx);
        }

        // Panel - GameOver
        public static void GameOver_Open(UIAppContext ctx) {
            PanelGameOverDomain.Open(ctx);
        }

        public static void GameOver_Close(UIAppContext ctx) {
            PanelGameOverDomain.Close(ctx);
        }

    }

}