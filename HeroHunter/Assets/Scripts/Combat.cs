﻿using System.Collections;
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
    public GameObject enemyGO;
    private IEnumerator coroutine;
    public bool pressed = false;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public bool enemyDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.value <= 0){
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public void AttackButton(){
        playerRoll = Random.Range(1,12);
        Debug.Log(playerRoll);
        if (1 <= playerRoll && playerRoll <= 4 && pressed == false){
            Debug.Log("Resist");
            //Instantiate(Resources.Load("Blood"), other.transform.position, other.transform.rotation);
        }
        if (5 <= playerRoll && playerRoll <= 9 && pressed == false){
            enemyhealth -= 10;
            enemyhealthBar.value = enemyhealth;
            //Instantiate(Resources.Load("Blood"), other.transform.position, other.transform.rotation);
        }
        if (10 <= playerRoll && playerRoll <= 12 && pressed == false){
            enemyhealth -= 20;
            enemyhealthBar.value = enemyhealth;
            //Instantiate(Resources.Load("Blood"), other.transform.position, other.transform.rotation);
        }
        pressed = true;
        if (enemyhealthBar.value <= 0){
            enemyDead = true;
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            enemyGO.GetComponent<Animator>().SetTrigger("die");
        }
        else{
            coroutine = EnemyAttack(2.0f);
            StartCoroutine(coroutine);
        }
        //coroutine = EnemyAttack(2.0f);
        //StartCoroutine(coroutine);
    }

    public void FleeButton(){
        //Did 11 to make it not a 50 / 50 flee
        playerRoll = Random.Range(1,11);
        Debug.Log("Flee attempt " + playerRoll);
        if (playerRoll % 2 == 0){
            Debug.Log("Flee");
        }
    }

    private IEnumerator EnemyAttack(float waitTime){
        yield return new WaitForSeconds(waitTime);
        playerRoll = Random.Range(1,12);
        if (1 <= playerRoll && playerRoll <= 6 && pressed == true){
            health -= 6;
            healthBar.value = health;
        }
        if (7 <= playerRoll && playerRoll <= 10 && pressed == true){
            health -= 3;
            healthBar.value = health;
        }
        if (11 <= playerRoll && playerRoll <= 12 && pressed == true){
            Debug.Log("Full resist");
        }
        pressed = false;
    }
}
