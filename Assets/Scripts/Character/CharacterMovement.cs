using UnityEngine;

/*
**  This class is responsible for constant forward movement.
**  Attached to Player Character and all NPCs    
**  @param speed: this variable defines how fast attached character moves.
 */

public class CharacterMovement : MonoBehaviour
{
    // Reference to character controller component.
    private CharacterController characterController;

    // Reference to character properties component.
    private CharacterProperties characterProperties;

    // Start is called before the first frame update
    void Start()
    {
        // Get character controller component and assign reference to it.
        characterController = GetComponent<CharacterController>();

        // Get character properties component and assign reference to it.
        characterProperties = GetComponent<CharacterProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move character if it is not being pushed.
        if(!characterProperties.isBeingPushed)
        {
            // Moves character forward
            characterController.SimpleMove(characterProperties.speed * transform.forward * Time.deltaTime);
        }
    }
}
