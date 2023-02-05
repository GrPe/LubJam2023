using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHQHealthDisplay : MonoBehaviour
{
    public Eatable eatable;
    public TMP_Text hpText;

    void Start()
    {
        hpText.text=eatable.GetDurability().ToString();
    }

    public void SetTMP_Text(int newHP)
    {
        hpText.text=newHP.ToString();
    }
}
