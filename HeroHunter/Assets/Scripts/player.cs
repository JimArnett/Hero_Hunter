﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameObject parentText;
    public GameObject club;
    public bool hasClub;
    public GameObject knightText;
    public GameObject kingText;
    public GameObject signText;
    private IEnumerator coroutine;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "parents"){
            parentText.SetActive(true);
            club.SetActive(true);
        }
        if (other.tag == "club"){
            Destroy(club);
            hasClub = true;
        }
        if (other.tag == "door" && hasClub){
            SceneManager.LoadScene(1);
        }
        if (other.tag == "knight"){
            knightText.SetActive(true);
            coroutine = EnemyAttack(2.0f);
            StartCoroutine(coroutine);
        }
        if (other.tag == "king"){
            kingText.SetActive(true);
            coroutine = KingAttack(2.0f);
            StartCoroutine(coroutine);
        }
        if (other.tag == "sign")
        {
            signText.SetActive(true);
        }
    }
    
    private IEnumerator EnemyAttack(float waitTime){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(2);
    }

    private IEnumerator KingAttack(float waitTime){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(4);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "parents"){
            parentText.SetActive(false);
        }

        if (other.tag == "sign")
        {
            signText.SetActive(false);
        }
    }
}
