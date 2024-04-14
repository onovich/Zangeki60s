using System;
using UnityEngine;
using UnityEngine.UI;
using MortiseFrame.Loom;

namespace Zangeki.UI {

    public class Panel_RoleHPElement : MonoBehaviour {

        [SerializeField] Image hp;

        public void EnableHP(bool enable) {
            hp.enabled = enable;
        }

    }

}