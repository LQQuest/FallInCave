using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class moving : MonoBehaviour
{
    public GameObject box;
    public GameObject grag;
    
    public Transform[] startingPositionsBox;
    public Transform[] startingPositionsGrag;
    public int randStartingPos = 1 ;
    public static moving instance = null;
    public static float timeScore = 1.8f;

    public float rnd_r_choice;
    public float rnd_l_choice;

    private float _timer = 0f;
    private GameMaster gm;

    void Awake()
    {
        if (instance == null)
        	instance = this;
        else if (instance != this)
        	Destroy (gameObject);

        
    }

    void Start()
    {
        StartCoroutine (Spawn ());
        Time.timeScale = 1;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }

    IEnumerator Spawn (){
        _timer += Time.deltaTime;
        while (!Player.lose)
        {
            randStartingPos = Random.Range(0,startingPositionsGrag.Length);
            transform.position = startingPositionsGrag[randStartingPos].position;
            Instantiate(grag, transform.position, Quaternion.identity);
            transform.position = startingPositionsBox[randStartingPos].position;
            Instantiate(box, transform.position, Quaternion.identity);
            
            

            if (randStartingPos == 0)
            rnd_l_choice = Random.Range(-0.7f, 0);
            else
            rnd_r_choice = Random.Range(0, 0.7f);


            yield return new WaitForSeconds(timeScore);
        }
    }
}
