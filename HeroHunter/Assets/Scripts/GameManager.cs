using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool enemyOne;
    public bool enemyTwo;
    public bool enemyThree;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        enemyOne = GameObject.FindGameObjectWithTag("player").GetComponent<Combat>().enemyDead;
    }

    // Update is called once per frame
    void Update()
    {
        enemyOne = GameObject.FindGameObjectWithTag("player").GetComponent<Combat>().enemyDead;
    }
}
