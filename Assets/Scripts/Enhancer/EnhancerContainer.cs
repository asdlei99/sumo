using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Holds list of references to all enhancers in the scene.
 */

public class EnhancerContainer : MonoBehaviour
{
    #region Singleton 
    public static EnhancerContainer Instance { get; private set; }

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    #region List of references to enhancers in the scene
    public List<GameObject> enchancers = new List<GameObject>();
    #endregion
}
