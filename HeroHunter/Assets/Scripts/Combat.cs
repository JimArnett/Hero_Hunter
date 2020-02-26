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
    public GameObject enemyGO;
    private IEnumerator coroutine;
    public bool pressed = false;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public bool enemyDead;
    public bool isDefending = false;
    public Text healthText;
    public Text enemyhealthText;
    public int critCounter;
    public Slider critCounterBar;

    private IEnumerator loseRoutine;
    private IEnumerator winRoutine;
    
    public AudioSource attackSound;

    private GameObject playerResist;
    private GameObject playerFull;
    private GameObject playerHalf;
    private GameObject enemyCrit;
    private GameObject enemyFull;
    private GameObject enemyResist;

    // Start is called before the first frame update
    void Start()
    {
        playerResist = GameObject.FindWithTag("pr");
        playerFull = GameObject.FindWithTag("pf");
        playerHalf = GameObject.FindWithTag("ph");
        enemyCrit = GameObject.FindWithTag("ec");
        enemyFull = GameObject.FindWithTag("ef");
        enemyResist = GameObject.FindWithTag("er");
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.value <= 0){
            healthBar.value = 0;
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            GetComponent<Animator>().SetTrigger("die");
            loseRoutine = deathTimer(2.0f);
            StartCoroutine(loseRoutine);
        }
    }

    public void AttackButton(){
        attackSound.Play();
        playerRoll = Random.Range(1,12);
        Debug.Log(playerRoll);
        if (critCounter < 3 ){
            if (1 <= playerRoll && playerRoll <= 4 && pressed == false){
                Debug.Log("Resist");
                //Instantiate(Resources.Load("Blood"), other.transform.position, other.transform.rotation);
                enemyResist.GetComponent<Animator>().SetTrigger("eResist");
            }
            if (5 <= playerRoll && playerRoll <= 9 && pressed == false){
                enemyhealth -= 10;
                enemyhealthBar.value = enemyhealth;
                //Instantiate(Resources.Load("Blood"), other.transform.position, other.transform.rotation);
                enemyFull.GetComponent<Animator>().SetTrigger("eFull");
                enemyhealthText.text = enemyhealth + "/100";
            }
            if (10 <= playerRoll && playerRoll <= 12 && pressed == false){
                enemyhealth -= 20;
                enemyhealthBar.value = enemyhealth;
                //Instantiate(Resources.Load("Blood"), other.transform.position, other.transform.rotation);
                enemyCrit.GetComponent<Animator>().SetTrigger("eCrit");
                enemyhealthText.text = enemyhealth + "/100";
            }
            critCounter += 1;
            critCounterBar.value = critCounter;
        }
        else{
            enemyhealth -= 20;
            enemyhealthBar.value = enemyhealth;
            //Instantiate(Resources.Load("Blood"), other.transform.position, other.transform.rotation);
            enemyCrit.GetComponent<Animator>().SetTrigger("eCrit");
            enemyhealthText.text = enemyhealth + "/100";
            critCounter = 0;
            critCounterBar.value = critCounter;
        }
        pressed = true;
        if (enemyhealthBar.value <= 0){
            enemyDead = true;
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            enemyGO.GetComponent<Animator>().SetTrigger("die");
            winRoutine = winTimer(2.0f);
            StartCoroutine(winRoutine);
        }
        else{
            coroutine = EnemyAttack(2.0f);
            StartCoroutine(coroutine);
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
        }
    }

    public void DefenseButton(){
        isDefending = true;
        Debug.Log("Defending");
        pressed = true;
        coroutine = EnemyAttack(2.0f);
        StartCoroutine(coroutine);
        buttonOne.SetActive(false);
        buttonTwo.SetActive(false);
    }

    private IEnumerator EnemyAttack(float waitTime){
        yield return new WaitForSeconds(waitTime);
        playerRoll = Random.Range(1,12);
        if (!isDefending){
            if (1 <= playerRoll && playerRoll <= 6 && pressed == true){
                health -= 6;
                healthBar.value = health;
                playerFull.GetComponent<Animator>().SetTrigger("pFull");
                healthText.text = health + "/100";
            }
            if (7 <= playerRoll && playerRoll <= 10 && pressed == true){
                health -= 3;
                healthBar.value = health;
                playerHalf.GetComponent<Animator>().SetTrigger("pHalf");
                healthText.text = health + "/100";
            }
            if (11 <= playerRoll && playerRoll <= 12 && pressed == true){
                Debug.Log("Full resist");
                playerResist.GetComponent<Animator>().SetTrigger("pResist");
            }
        }
        else{
            //blockSound.Play();
        }
        pressed = false;
        isDefending = false;
        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);
    }
    
    private IEnumerator deathTimer(float waitTime){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
    private IEnumerator winTimer(float waitTime){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(3);
    }
}
