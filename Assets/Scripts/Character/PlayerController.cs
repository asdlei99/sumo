using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    // Singleton pointer
    public static PlayerController Instance { get; private set; }

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

    // Rotation sensivity 
    [SerializeField]
    private float playerRotationSensivity = 10f;
    #endregion

    #region Methods
    // Update is called once per frame
    private void Update()
    {
        SetPlayer();

        ListenTouchInput();
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
                Quaternion rotation = Quaternion.Euler(0f, touch.deltaPosition.x * Time.deltaTime * playerRotationSensivity, 0f);
                player.transform.Rotate(rotation.eulerAngles);
            }
        }
    }

    /**
     * Set player reference as first item in sumos list in SumoContainer, if it is null. 
     */
    private void SetPlayer()
    {
        if (PlayerController.Instance.player == null)
            PlayerController.Instance.player = SumoContainer.Instance.sumos[0];
    }
    #endregion
}
