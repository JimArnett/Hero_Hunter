using System.Collections;
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
    public GameObject dungeonText;
    public GameObject sign2Text;
    private IEnumerator coroutine;

    public AudioSource laughSound;
    public AudioSource laugh2Sound;
    
    private GameObject closedDoor;
    private GameObject openedDoor;

    // Start is called before the first frame update
    void Start()
    {
        closedDoor = GameObject.FindWithTag("closed");
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
            closedDoor.GetComponent<Animator>().SetTrigger("pleaseOpen");
        }
        if (other.tag == "door" && hasClub){
            SceneManager.LoadScene(1);
        }
        if (other.tag == "knight"){
            knightText.SetActive(true);
            laughSound.Play();
            coroutine = EnemyAttack(5.0f);
            StartCoroutine(coroutine);
        }
        if (other.tag == "king"){
            laugh2Sound.Play();
            kingText.SetActive(true);
            coroutine = KingAttack(5.0f);
            StartCoroutine(coroutine);
        }
        if (other.tag == "sign")
        {
            signText.SetActive(true);
        }
        if (other.tag == "dungeon")
        {
            dungeonText.SetActive(true);
        }
        if (other.tag == "sign2")
        {
            sign2Text.SetActive(true);
        }
        if (other.tag == "garden")
        {
            SceneManager.LoadScene(6);
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
        if (other.tag == "dungeon")
        {
            dungeonText.SetActive(false);
        }
        if (other.tag == "sign2")
        {
            sign2Text.SetActive(false);
        }
    }
}
