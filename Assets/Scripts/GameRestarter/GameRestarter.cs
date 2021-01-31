using System.Collections;
using UnityEngine;

public class GameRestarter : MonoBehaviour
{
    // Singleton pointer
    public static GameRestarter Instance { get; private set; }

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Restart(bool isWin)
    {
        StartCoroutine(RestartCoroutine(isWin));
    }

    public IEnumerator RestartCoroutine(bool isWin)
    {
        // Hide in game ui
        InGameUI.Instance.Hide();

        // Destroy all enhancers in the scene.
        DestroyEnhancers();

        // Destroy all sumos in the scene.
        DestroySumos();

        // Display game over ui
        GameStarterUI.Instance.DisplayGameOverUI(isWin);

        // Wait for 2 seconds to display ui.
        yield return new WaitForSeconds(2f);

        // Remove game over ui
        GameStarterUI.Instance.RemoveGameOverUI();

        // Show in game ui
        InGameUI.Instance.Show();

        // Spawn enhancers back
        EnhancerSpawner.Instance.InitialSpawn();

        // Spawn sumos back
        SumoSpawner.Instance.InitialSpawn();

        // Reset timer
        Timer.Instance.Reset();
        
    }

    private void DestroyEnhancers()
    {
        // Destroy each enhancer in the list.
        foreach (GameObject enhancer in EnhancerContainer.Instance.enchancers)
            Destroy(enhancer);
    }

    private void DestroySumos()
    {
        // Destroy each enhancer in the list.
        foreach (GameObject sumo in SumoContainer.Instance.sumos)
            Destroy(sumo);
    }

    
}
