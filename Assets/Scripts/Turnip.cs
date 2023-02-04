using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnip : MonoBehaviour
{
    public GameObject UI;

    private void OnDestroy()
    {
        UI.SetActive(true);        
    }
}
