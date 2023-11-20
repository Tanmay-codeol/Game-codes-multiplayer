// using Photon.Pun;
// using Photon.Realtime;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Damage : MonoBehaviour
// {
//     public int health = 100;
//     public int damage = 100;
//     public Slider slider;
//     public int CurrHealth;
//     private PhotonView photonView;

//     public int AttackCoolDown;
//     public int Range_Horizontal = 100;
//     public int Range_Vertical = 1;
//     GameObject selectedGameObject;


//     void Start()
//     {
//         photonView = GetComponent<PhotonView>();
//         // Parse the game object name to determine health and damage
//         if (gameObject.name.Contains("Infantry"))
//         {   
//             health = 50;
//             damage = 20;

//             // if (gameObject.name.Contains("red"))
//             // {
//             //     health = 50;
//             //     damage = 2;
//             // }
//             // else if (gameObject.name.Contains("blue"))
//             // {
//             //     health = 100;
//             //     damage = 1;
//             // }
//         }
//         else if (gameObject.name.Contains("Artilery"))
//         {
//             health = 75;
//             damage = 20;

//         }
//         else if (gameObject.name.Contains("Jeep"))
//         {
//             health = 50;
//             damage = 10;

//         }
//         else if (gameObject.name.Contains("Air"))
//         {
//             health = 20;
//             damage = 40;

//         }
//         else if (gameObject.name.Contains("Tank"))
//         {
//             health = 130;
//             damage = 50;

//         }
//         else if (gameObject.name.Contains("Corps"))
//         {
//             health = 200;
//             damage = 30;

//         }
//         else if (gameObject.name.Contains("Radar"))
//         {
//             health = 10;
//             damage = 0;

//         }

//         // else if(gameObject.name.Contains(""))
//         // Repeat the above for other game object names

//         CurrHealth = health;
//         slider.maxValue = CurrHealth;
//         slider.value = CurrHealth;
//     }

//     public bool TakeDamage(int dmg)
//     {
//         CurrHealth -= dmg;

//         if (CurrHealth <= 0)
//             return true;
//         else
//             return false;
//     }

//     void Update()
//     {
//         // if (health <= 0)
//         // {
//         //     Destroy(gameObject);
            
//         // }

//         slider.value = health;
//     }

//     void OnMouseEnter()
//     {
//         slider.gameObject.SetActive(true);
//     }

//     void OnMouseDown(){

//         selectedGameObject = gameObject;
        
//     }

//     void OnMouseExit()
//     {
//         slider.gameObject.SetActive(false);
//     }
//     public void Attack(GameObject target)
// {
//     // Reduce target unit's health by the attacker's damage
//     target.GetComponent<Damage>().health -= damage;

//     // Check if the target unit has been destroyed
//     if (target.GetComponent<Damage>().health <= 0)
//     {
//         Destroy(target);
//     }
// }
// [PunRPC]
// void DestroyObject()
// {
//     PhotonNetwork.Destroy(gameObject);
// }
// // photonView.RPC("DestroyObject", RpcTarget.All);
// // photonView.RPC("DestroyObject", RpcTarget.All);
// void OnCollisionEnter(Collision hit)
// {
//     Damage damageComponent = hit.transform.gameObject.GetComponent<Damage>();
    
//     if (damageComponent != null)
//     {
//         // check if the selected game object is colliding with the opposite team's game object
//         if (selectedGameObject.name.Contains("(red)") && hit.gameObject.name.Contains("(blue)"))
//         {
//             // Deal 1000 damage to the already present opposite team game object
//             if (selectedGameObject == gameObject)
//             {
//                 damageComponent.health -= 1000;
//                 damageComponent.slider.value = damageComponent.health;
//                 // Destroy(hit.gameObject);
//                 photonView.RPC("DestroyObject", RpcTarget.All);
//             }
//         }
//         else if (selectedGameObject.name.Contains("(blue)") && hit.gameObject.name.Contains("(red)"))
//         {
//             // Deal 1000 damage to the already present opposite team game object
//             if (selectedGameObject == gameObject)
//             {
//                 damageComponent.health -= 1000;
//                 damageComponent.slider.value = damageComponent.health;
//                 // Destroy(hit.gameObject);
//                 photonView.RPC("DestroyObject", RpcTarget.All);
//             }
//         }
//     }
// }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Damage : MonoBehaviourPunCallbacks
{
    public int health = 100;
    public int damage = 100;
    public Slider slider;
    public int CurrHealth;

    public int AttackCoolDown;
    public int Range_Horizontal = 100;
    public int Range_Vertical = 1;

    private bool hasMoved = false;
    public GameManagerr gameManager;
      

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerr>();
        // Parse the game object name to determine health and damage
        if (gameObject.name.Contains("Infantry"))
        {   
            health = 50;
            damage = 200;

            // if (gameObject.name.Contains("red"))
            // {
            //     health = 50;
            //     damage = 2;
            // }
            // else if (gameObject.name.Contains("blue"))
            // {
            //     health = 100;
            //     damage = 1;
            // }
        }
        else if (gameObject.name.Contains("Artilery"))
        {
            health = 75;
            damage = 200;

        }
        else if (gameObject.name.Contains("Jeep"))
        {
            health = 50;
            damage = 1000;

        }
        else if (gameObject.name.Contains("Air"))
        {
            health = 20;
            damage = 400;

        }
        else if (gameObject.name.Contains("Tank"))
        {
            health = 130;
            damage = 500;

        }
        else if (gameObject.name.Contains("Corps"))
        {
            health = 200;
            damage = 300;

        }
        else if (gameObject.name.Contains("Radar"))
        {
            health = 10;
            damage = 200;

        }

        // else if(gameObject.name.Contains(""))
        // Repeat the above for other game object names

        CurrHealth = health;
        slider.maxValue = CurrHealth;
        slider.value = CurrHealth;
    }
    [PunRPC]
    public bool TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
            return true;
        else
            return false;
    }
    

    void Update()
    {
        if (health <= 0)
        {
            // If the game object is not of the red team, only disable the Damage script
            // so it can be re-enabled later
            
                
                Destroy(gameObject);
            
        }

        slider.value = health;
    }

    void OnMouseEnter()
    {
        slider.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        slider.gameObject.SetActive(false);
    }
    public void Attack(GameObject target)
{
    // Reduce target unit's health by  attacker's damage
    target.GetComponent<Damage>().health -= damage;

    // Check if the target unit has been destroyed
    if (target.GetComponent<Damage>().health <= 0)
    {
        Destroy(target);
    }

    hasMoved = false;
}
void OnCollisionEnter(Collision hit)
{
    // Damage damageComponent = hit.transform.gameObject.GetComponent<Damage>();



     

      GameManagerr gameManager = FindObjectOfType<GameManagerr>();

        // Call the OnObjectCollision method in the GameManager script, passing both game objects involved in the collision as arguments
        gameManager.OnObjectCollision(gameObject, hit.gameObject);
    // if (damageComponent != null && hit.transform.gameObject != gameObject)
    // {
    //     if (gameObject.name.Contains("(red)") && hit.gameObject.name.Contains("(blue)"))
    //     {
    //         if (GameManagerr.lastMoved != gameObject) // Only deal damage if the last moved object was not this object
    //         {
    //             damageComponent.health -= damage;
    //             damageComponent.slider.value = damageComponent.health;
    //             Debug.Log("Red damaged blue!");
    //             // GameManagerr.lastMoved = gameObject;
    //         }
    //     }
    //     else if (gameObject.name.Contains("(blue)") && hit.gameObject.name.Contains("(red)"))
    //     {
    //         if (GameManagerr.lastMoved != gameObject) // Only deal damage if the last moved object was not this object
    //         {
    //             damageComponent.health -= damage;
    //             damageComponent.slider.value = damageComponent.health;
    //             Debug.Log("Blue damaged red!");
    //             // GameManagerr.lastMoved = gameObject;
    //         }
    //     }
    // }

    // Called when this game object is moved


}
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
        }
    }
    public void Move()
    {
        GameManagerr gameManager = FindObjectOfType<GameManagerr>();
        gameManager.OnObjectMoved(gameObject);


    }
}





// using Photon.Pun;
// using Photon.Realtime;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Damage : MonoBehaviour
// {
//     public int health = 100;
//     public int damage = 100;
//     public Slider slider;
//     public int CurrHealth;
//     private PhotonView photonView;

//     public int AttackCoolDown;
//     public int Range_Horizontal = 100;
//     public int Range_Vertical = 1;
//     GameObject selectedGameObject;


//     void Start()
//     {
//         photonView = GetComponent<PhotonView>();
//         // Parse the game object name to determine health and damage
//         if (gameObject.name.Contains("Infantry"))
//         {   
//             health = 50;
//             damage = 20;

//             // if (gameObject.name.Contains("red"))
//             // {
//             //     health = 50;
//             //     damage = 2;
//             // }
//             // else if (gameObject.name.Contains("blue"))
//             // {
//             //     health = 100;
//             //     damage = 1;
//             // }
//         }
//         else if (gameObject.name.Contains("Artilery"))
//         {
//             health = 75;
//             damage = 20;

//         }
//         else if (gameObject.name.Contains("Jeep"))
//         {
//             health = 50;
//             damage = 10;

//         }
//         else if (gameObject.name.Contains("Air"))
//         {
//             health = 20;
//             damage = 40;

//         }
//         else if (gameObject.name.Contains("Tank"))
//         {
//             health = 130;
//             damage = 50;

//         }
//         else if (gameObject.name.Contains("Corps"))
//         {
//             health = 200;
//             damage = 30;

//         }
//         else if (gameObject.name.Contains("Radar"))
//         {
//             health = 10;
//             damage = 0;

//         }

//         // else if(gameObject.name.Contains(""))
//         // Repeat the above for other game object names

//         CurrHealth = health;
//         slider.maxValue = CurrHealth;
//         slider.value = CurrHealth;
//     }

//     public bool TakeDamage(int dmg)
//     {
//         CurrHealth -= dmg;

//         if (CurrHealth <= 0)
//             return true;
//         else
//             return false;
//     }

//     void Update()
//     {
//         // if (health <= 0)
//         // {
//         //     Destroy(gameObject);
            
//         // }

//         slider.value = health;
//     }

//     void OnMouseEnter()
//     {
//         slider.gameObject.SetActive(true);
//     }

//     void OnMouseDown(){

//         selectedGameObject = gameObject;
        
//     }

//     void OnMouseExit()
//     {
//         slider.gameObject.SetActive(false);
//     }
//     public void Attack(GameObject target)
// {
//     // Reduce target unit's health by the attacker's damage
//     target.GetComponent<Damage>().health -= damage;

//     // Check if the target unit has been destroyed
//     if (target.GetComponent<Damage>().health <= 0)
//     {
//         Destroy(target);
//     }
// }
// [PunRPC]
// void DestroyObject()
// {
//     PhotonNetwork.Destroy(gameObject);
// }
// // photonView.RPC("DestroyObject", RpcTarget.All);
// // photonView.RPC("DestroyObject", RpcTarget.All);
// void OnCollisionEnter(Collision hit)
// {
//     Damage damageComponent = hit.transform.gameObject.GetComponent<Damage>();
    
//     if (damageComponent != null)
//     {
//         // check if the selected game object is colliding with the opposite team's game object
//         if (selectedGameObject.name.Contains("(red)") && hit.gameObject.name.Contains("(blue)"))
//         {
//             // Deal 1000 damage to the already present opposite team game object
//             if (selectedGameObject != gameObject)
//             {
//                 damageComponent.health -= 1000;
//                 damageComponent.slider.value = damageComponent.health;
//                 // Destroy(hit.gameObject);
//                 photonView.RPC("DestroyObject", RpcTarget.All);
//             }
//         }
//         else if (selectedGameObject.name.Contains("(blue)") && hit.gameObject.name.Contains("(red)"))
//         {
//             // Deal 1000 damage to the already present opposite team game object
//             if (selectedGameObject != gameObject)
//             {
//                 damageComponent.health -= 1000;
//                 damageComponent.slider.value = damageComponent.health;
//                 // Destroy(hit.gameObject);
//                 photonView.RPC("DestroyObject", RpcTarget.All);
//             }
//         }
//     }
// }






// }