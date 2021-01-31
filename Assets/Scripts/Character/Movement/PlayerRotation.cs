using UnityEngine;

/**
 * This class is responsible for reading user inputs and rotation of the player character based on input.
 */
namespace Sumo.Character.Controller
{
    public class PlayerRotation : MonoBehaviour
    {
        #region Singleton
        // Singleton pointer
        public static PlayerRotation Instance { get; private set; }

        private void Awake()
        {
            // Set this class as Singleton
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        #endregion

        #region Properties
        // Reference to player
        private GameObject player;

        // Rotation sensivity for touch input.
        [SerializeField]
        private float touchSensivity = 10f;

        // Rotation sensivity for mouse input
        [SerializeField]
        private float mouseSensivity = 100f;
        #endregion

        #region Methods
        // Update is called once per frame
        private void Update()
        {
            // Assign reference to player character if it is null.
            SetPlayer();

            // Listen for touch input and rotate player based on that.
            ListenTouchInput();

            // Listen for mouse input and rotate player based on that.
            //ListenMouseInput();
        }

        /**
         * Listens for touch input and rotates player on touch move. 
         */
        private void ListenTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                // Move the cube if the screen has the finger moving.
                if (touch.phase == TouchPhase.Moved)
                {
                    Quaternion rotation = Quaternion.Euler(0f, touch.deltaPosition.x * Time.deltaTime * touchSensivity, 0f);
                    player.transform.Rotate(rotation.eulerAngles);
                }
            }
        }

        /**
         * Listens for mouse input and rotates player on touch move. 
        private void ListenMouseInput()
        {
            if (Input.GetMouseButton(0))
            {
                Quaternion rotation = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0f);
                player.transform.Rotate(rotation.eulerAngles);
            }
        }
        */

        /**
         * Set player reference as first item in sumos list in SumoContainer, if it is null. 
         */
        private void SetPlayer()
        {
            if (PlayerRotation.Instance.player == null)
                PlayerRotation.Instance.player = Sumo.SumoManagement.SumoContainer.Instance.sumos[0];
        }
        #endregion
    }
}
