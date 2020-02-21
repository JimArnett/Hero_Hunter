using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameObject parentText;
    public GameObject club;
    public bool hasClub;

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
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "parents"){
            parentText.SetActive(false);
        }
    }
}
