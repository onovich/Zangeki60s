using System.Diagnostics;

namespace Zangeki {

    public class GameFSMComponent {

        public GameStatus status;

        public bool notInGame_isEntering;
        public bool gaming_isEntering;
        public bool gameOver_isEntering;
        public float gameOver_enterTime;

        public void NotInGame_Enter() {
            Reset();
            status = GameStatus.NotInGame;
            notInGame_isEntering = true;
        }

        public void Gaming_Enter() {
            Reset();
            status = GameStatus.Gaming;
            gaming_isEntering = true;
        }

        public void GameOver_Enter(float enterTime) {
            Reset();
            status = GameStatus.GameOver;
            gameOver_isEntering = true;
            gameOver_enterTime = enterTime;
        }

        public void Reset(){
            notInGame_isEntering = false;
            gaming_isEntering = false;
            gameOver_isEntering = false;
            gameOver_enterTime = 0;
        }

    }

}