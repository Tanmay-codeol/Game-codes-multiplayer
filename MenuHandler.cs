using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MenuHandler : MonoBehaviour
{
    public GameObject hostMenu;
    public GameObject joinedMenu;

    public static bool isHost;

    public int PlayerNum;



    // Start is called before the first frame update
    void Start()
    {
        PlayerNum = PhotonNetwork.PlayerList.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMenu()
    {
        Debug.Log(PlayerNum);
        if (PlayerNum == 1)
        {
            SetHostMenu();
        }

        else
        {
            SetClientMenu();
        }
    }

    public void SetHostMenu()
    {
        hostMenu.SetActive(true);
        joinedMenu.SetActive(false);
    }

    public void SetClientMenu()
    {
        hostMenu.SetActive(false);
        joinedMenu.SetActive(true);
    }
}
