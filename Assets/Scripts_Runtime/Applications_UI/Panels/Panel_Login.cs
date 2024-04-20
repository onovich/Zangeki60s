using System;
using UnityEngine;
using UnityEngine.UI;
using MortiseFrame.Loom;
using MortiseFrame.Swing;

namespace Zangeki.UI {

    public class Panel_Login : MonoBehaviour, IPanel {

        [SerializeField] Button startGameBtn;
        [SerializeField] Button exitGameBtn;
        [SerializeField] Transform bgTrans;
        [SerializeField] float bgEasingFrequency;
        [SerializeField] float bgEasingAmplitude;
        Vector2 bgOriginPos;
        float bgEasingCurrentTime;

        public Action OnClickStartGameHandle;
        public Action OnClickExitGameHandle;

        public void Ctor() {
            startGameBtn.onClick.AddListener(() => {
                OnClickStartGameHandle?.Invoke();
            });

            exitGameBtn.onClick.AddListener(() => {
                OnClickExitGameHandle?.Invoke();
            });
            bgOriginPos = bgTrans.localPosition;
            bgEasingCurrentTime = 0f;
        }

        void OnDestroy() {
            startGameBtn.onClick.RemoveAllListeners();
            exitGameBtn.onClick.RemoveAllListeners();
            OnClickStartGameHandle = null;
            OnClickExitGameHandle = null;
        }

        public void Tick(float dt) {
            var offset = WaveHelper.Wave(bgEasingFrequency, bgEasingAmplitude, bgEasingCurrentTime, 0, WaveType.Sine);
            var pos = bgOriginPos + new Vector2(0, offset);
            bgTrans.localPosition = pos;
            bgEasingCurrentTime += dt;
        }

    }

}