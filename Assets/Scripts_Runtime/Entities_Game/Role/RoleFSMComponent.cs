using System.Numerics;

namespace Zangeki {

    public class RoleFSMComponent {

        public RoleFSMStatus status;

        public bool idle_isEntering;
        public bool dead_isEntering;
        public bool leaving_isEntering;
        public bool casting_isEntering;

        public int leaving_totalFrame;
        public int leaving_currentFrame;

        public int casting_totalFrame;
        public int casting_slashFrame;
        public int casting_damageFrame;
        public int casting_currentFrame;

        public RoleFSMComponent() { }

        public void EnterIdle() {
            status = RoleFSMStatus.Idle;
            idle_isEntering = true;
        }

        public void EnterDead() {
            status = RoleFSMStatus.Dead;
            dead_isEntering = true;
        }

        public void EnterLeaving(int totalFrame) {
            status = RoleFSMStatus.Leaving;
            leaving_isEntering = true;
            leaving_totalFrame = totalFrame;
            leaving_currentFrame = 0;
        }

        public void Leaving_IncFrame() {
            leaving_currentFrame += 1;
        }

        public void EnterCasting(int totalFrame, int damageFrame, int slashFrame) {
            status = RoleFSMStatus.Casting;
            casting_isEntering = true;
            casting_totalFrame = totalFrame;
            casting_damageFrame = damageFrame;
            casting_slashFrame = slashFrame;
            casting_currentFrame = 0;
        }

        public void Casting_IncFrame() {
            casting_currentFrame += 1;
        }

    }

}