using System.Numerics;

namespace Zangeki {

    public class RoleFSMComponent {

        public RoleFSMStatus status;

        public bool idle_isEntering;
        public bool dead_isEntering;
        public bool leaving_isEntering;

        public float leaving_duration;
        public float leaving_currentTimer;

        public RoleFSMComponent() { }

        public void EnterIdle() {
            status = RoleFSMStatus.Idle;
            idle_isEntering = true;
        }

        public void EnterDead() {
            status = RoleFSMStatus.Dead;
            dead_isEntering = true;
        }

        public void EnterLeaving( float duration) {
            status = RoleFSMStatus.Leaving;
            leaving_isEntering = true;
            leaving_duration = duration;
            leaving_currentTimer = 0;
        }

        public void Leaving_DecTimer(float fixdt) {
            leaving_currentTimer += fixdt;
        }

    }

}