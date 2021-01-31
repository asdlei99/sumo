using UnityEngine;

/*
**  This class is responsible for constant forward movement.
**  Attached to Player Character and all NPCs    
**  @param speed: this variable defines how fast attached character moves.
 */

namespace Sumo.Character.Controller
{
    public class Movement : MonoBehaviour
    {
        // Reference to character controller component.
        private CharacterController characterController;

        // Reference to push component
        private Sumo.Character.Collision.Push push;

        // Movement speed.
        [SerializeField]
        private float speed = 0;


        // Start is called before the first frame update
        void Start()
        {
            // Get character controller component and assign reference to it.
            characterController = GetComponent<CharacterController>();
            // Get push component and assign reference to it.
            push = GetComponent<Sumo.Character.Collision.Push>();
        }

        // Update is called once per frame
        void Update()
        {
            // Move character if it is not being pushed.
            if (!push.isBeingPushed)
            {
                // Moves character forward
                characterController.Move(speed * transform.forward * Time.deltaTime);
                characterController.Move(-9.98f * transform.up * Time.deltaTime);
            }
        }
    }
}

