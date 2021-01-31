using UnityEngine;

public class CharacterProperties : MonoBehaviour
{
    public float speed = 50f;
    public float pushForce = 2f;

    public float maxScale = 10f;
    public float maxPushForce = 10;

    public bool isBeingPushed = false;

    public GameObject lastHitSumo;
}
