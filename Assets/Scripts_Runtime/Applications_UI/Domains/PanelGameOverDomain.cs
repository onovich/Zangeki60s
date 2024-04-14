using System;
using UnityEngine;
using UnityEngine.UI;

namespace Zangeki.UI {

    public static class PanelGameOverDomain {

        public static void Open(UIAppContext ctx) {

            var has = ctx.UniquePanel_TryGet<Panel_GameOver>(out var panel);
            if (has) {
                return;
            }

            panel = ctx.uiCore.UniquePanel_Open<Panel_GameOver>();
            panel.Ctor();

            panel.OnClickRestartGameHandle += () => {
                ctx.evt.GameOver_OnRestartGameClick();
            };

            panel.OnClickExitGameHandle += () => {
                ctx.evt.GameOver_OnExitGameClick();
            };

        }

        public static void Close(UIAppContext ctx) {
            var has = ctx.UniquePanel_TryGet<Panel_GameOver>(out var panel);
            if (!has) {
                return;
            }
            ctx.uiCore.UniquePanel_Close<Panel_GameOver>();
        }

    }

}