using UnityEngine;

/**
 * This class is responsible for character scale management.
 */

namespace Sumo.Character
{
    public class Scale : MonoBehaviour
    {
        // Max scale attached gameobject can have.
        [SerializeField]
        private float maxScale = 10f;

        // Scales attached gameobject by given amount.
        public void ScaleUp(float scaleBy)
        {
            // Check if this addition will exceed max scale. If not scale up.
            if((transform.localScale + transform.localScale * scaleBy).x < maxScale)
                transform.localScale += transform.localScale * scaleBy;
        }

    }
}

