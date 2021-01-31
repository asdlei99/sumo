using UnityEngine;

namespace Sumo.EnhancerManagement
{
    public class EnhancerDestroyer: MonoBehaviour
    {

        // Reference to sumo that picks this enhance
        private GameObject picker = null;

        private void OnDestroy()
        {
            if (picker == null)
            {
                Debug.Log("Picker is not set!");
                return;
            }

            // Remove enhancer from enhancers list.
            EnhancerContainer.Instance.enchancers.Remove(gameObject);

            Sumo.Character.Collision.Push push = picker.GetComponent<Sumo.Character.Collision.Push>();

            // Spawn new pickable in random position.
            EnhancerSpawner.Instance.Spawn();

            // Scale character up by 10% if it is now reached it's max scale.
            picker.GetComponent<Sumo.Character.Scale>().ScaleUp(0.1f);

            // Increase push modifier by 10% if it is now reached it's max push force.
            if (push.pushForce < push.maxPushForce)
                push.pushForce += push.pushForce * 0.1f;

            // Add score to character if it is main player.
            picker.GetComponent<Sumo.Character.Score>().AddScore(100);
        }

        public void SetPicker(GameObject newPicker)
        {
            if(picker == null)
                picker = newPicker;
        }
    }
}
