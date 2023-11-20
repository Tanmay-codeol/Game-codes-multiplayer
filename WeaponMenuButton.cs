using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMenuButton : MonoBehaviour
{
    public GameObject WeaponPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPanel()
    {
        if (WeaponPanel.activeSelf == true)
        {
            HidePanel();
        }

        else
        {
            WeaponPanel.SetActive(true);
        }

    }

    public void HidePanel()
    {
        WeaponPanel.SetActive(false);
    }
}
