using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{

    public int playerRoll;
    public int health = 100;
    public Slider healthBar;
    public int enemyhealth = 100;
    public Slider enemyhealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackButton(){
        playerRoll = Random.Range(1,12);
        Debug.Log(playerRoll);
        if (1 <= playerRoll && playerRoll <= 4){
            Debug.Log("Resist");
        }
        if (5 <= playerRoll && playerRoll <= 9){
            enemyhealth -= 10;
            enemyhealthBar.value = enemyhealth;
        }
        if (10 <= playerRoll && playerRoll <= 12){
            enemyhealth -= 20;
            enemyhealthBar.value = enemyhealth;
        }
        EnemyAttack();
    }

    public void FleeButton(){
        //Did 11 to make it not a 50 / 50 flee
        playerRoll = Random.Range(1,11);
        Debug.Log("Flee attempt " + playerRoll);
        if (playerRoll % 2 == 0){
            Debug.Log("Flee");
        }
    }

    public void EnemyAttack(){
        playerRoll = Random.Range(1,12);
        if (1 <= playerRoll && playerRoll <= 6){
            health -= 6;
            healthBar.value = health;
        }
        if (7 <= playerRoll && playerRoll <= 10){
            health -= 3;
            healthBar.value = health;
        }
        if (11 <= playerRoll && playerRoll <= 12){
            Debug.Log("Full resist");
        }
    }
}
