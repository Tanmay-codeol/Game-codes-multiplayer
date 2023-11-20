// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public enum BattleState { Placement, Attacking , WON, LOST }

// public class BattleSystem : MonoBehaviour
// {
// 	public GameObject enemyPrefab;

	

// 	Damage playerUnit;
// 	Damage enemyUnit;

// 	public Text dialogueText;

// 	// public BattleHUD playerHUD;
// 	// public BattleHUD enemyHUD;

// 	public BattleState state;

//     // Start is called before the first frame update
//     void Start()
//     {
// 		state = BattleState.Placement;
// 		GameObject playerGO = GameObject.Find("Infantry (Blue)");
// 		StartCoroutine(SetupBattle(playerGO));
//     }
        
//         public void OnAttackButton()
//         {
//             state = BattleState.Attacking;

//             StartCoroutine(PlayerAttack());
//         }

// 	IEnumerator SetupBattle(GameObject playerGO)
// 	{
// 		playerUnit = playerGO.GetComponent<Damage>();

// 		GameObject enemyGO = GameObject.Find("Infantry (red)");
// 		enemyUnit = enemyGO.GetComponent<Damage>();

// 		// playerHUD.SetHUD(playerUnit);
// 		// enemyHUD.SetHUD(enemyUnit);

// 		yield return new WaitForSeconds(2f);

// 		state = BattleState.Attacking;
// 		PlayerTurn();
// 	}

// 	IEnumerator PlayerAttack()
// 	{
// 		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

// 		// enemyHUD.SetHP(enemyUnit.currentHP);
		

// 		yield return new WaitForSeconds(2f);

// 		if(isDead)
// 		{
// 			state = BattleState.WON;
// 			EndBattle();
// 		} else
// 		{
// 			state = BattleState.LOST;
// 			// StartCoroutine(EnemyTurn());
// 		}
// 	}

	


// 	void EndBattle()
// 	{
// 		if(state == BattleState.WON)
// 		{
// 			// dialogueText.text = "You won the battle!";
// 		} else if (state == BattleState.LOST)
// 		{
// 			// dialogueText.text = "You were defeated.";
// 		}
// 	}

// 	void PlayerTurn()
// 	{
// 		// dialogueText.text = "Choose an action:";
// 	}

	


// 	}