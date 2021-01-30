using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Singleton pointer
    public static InputManager Instance { get; private set; }

    // Reference to player
    private GameObject player;

    [SerializeField]
    private float playerRotationSensivity = 100f;

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        InputManager.Instance.player = Sumos.Instance.SumosInGame[0];
    }

    // Update is called once per frame
    private void Update()
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
}
