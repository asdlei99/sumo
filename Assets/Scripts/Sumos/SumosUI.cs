using UnityEngine;
using TMPro;

public class SumosUI : MonoBehaviour
{
    // Singleton pointer
    public static SumosUI Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI sumosText;

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        sumosText.text = Sumos.Instance.SumosInGame.Count.ToString();
    }
}
