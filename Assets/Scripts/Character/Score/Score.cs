using UnityEngine;

/**
 * This class hold character's score. And modifies it.
 */

namespace Sumo.Character
{
    public class Score : MonoBehaviour
    {
        [SerializeField]
        private int characterScore = 0;
        public int CharacterScore { get { return characterScore; } }

        private void Start()
        {
            if (tag == "Player")
                Sumo.UI.ScoreUI.Instance.UpdateUI(characterScore);
        }

        public void AddScore(int amount)
        {
            characterScore += amount;
            if (tag == "Player")
                Sumo.UI.ScoreUI.Instance.UpdateUI(characterScore);
        }
    }
}


