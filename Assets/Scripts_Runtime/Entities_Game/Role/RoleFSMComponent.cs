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
        public float leaving_currentTimer;

        public int casting_totalFrame;
        public int casting_slashFrame;
        public int casting_damageFrame;
        public int casting_currentFrame;
        public float casting_currentTimer;

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

        public void Leaving_IncFrame(float dt, float stateFrameInterval) {
            leaving_currentTimer += dt;
            if (leaving_currentTimer < stateFrameInterval) {
                return;
            }
            leaving_currentTimer = 0;
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

        public void Casting_IncFrame(float dt, float stateFrameInterval) {
            casting_currentTimer += 1;
            if (casting_currentTimer < stateFrameInterval) {
                return;
            }
            casting_currentTimer = 0;
            casting_currentFrame += 1;
        }

    }

}