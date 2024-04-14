using System;
using UnityEngine;
using UnityEngine.UI;
using MortiseFrame.Loom;

namespace Zangeki.UI {

    public class Panel_GameOver : MonoBehaviour, IPanel {

        [SerializeField] Button restartGameBtn;
        [SerializeField] Button exitGameBtn;

        public Action OnClickRestartGameHandle;
        public Action OnClickExitGameHandle;

        public void Ctor() {
            restartGameBtn.onClick.AddListener(() => {
                OnClickRestartGameHandle?.Invoke();
            });

            exitGameBtn.onClick.AddListener(() => {
                OnClickExitGameHandle?.Invoke();
            });
        }

        void OnDestroy() {
            restartGameBtn.onClick.RemoveAllListeners();
            exitGameBtn.onClick.RemoveAllListeners();
            OnClickRestartGameHandle = null;
            OnClickExitGameHandle = null;
        }

    }

}