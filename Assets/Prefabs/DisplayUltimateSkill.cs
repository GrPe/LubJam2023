using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUltimateSkill : MonoBehaviour
{
    public List<GameObject> stageToDisplay = new List<GameObject>();
    public GameObject nextActivator = null;
    public float timeToDeactive = 0.5f;
    public float timeToActivationNext = 0.5f;

    private void OnEnable()
    {
        foreach (GameObject go in stageToDisplay)
        {
            go.SetActive(true);
        }
        StartCoroutine(DisableAtack());
    }

    IEnumerator DisableAtack()
    {
        yield return new WaitForSeconds(timeToDeactive);
        foreach (GameObject go in stageToDisplay)
        {
            go.SetActive(false);
        }
        nextActivator.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
