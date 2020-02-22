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
    }
    
    private IEnumerator EnemyAttack(float waitTime){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(2);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "parents"){
            parentText.SetActive(false);
        }
    }
}
