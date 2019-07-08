using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class changePosX : MonoBehaviour
{
    [SerializeField]
    public GameObject gem;
    private float moveSpeed = 1.2f;
    private float fallSpeed = 1.2f;
    private int flag;
    private float rnd_r_choice;
    private float rnd_l_choice;
    private Animator animator;
    private int rnd;

    private GameMaster gm;
    

    void Awake()
    {
        flag = moving.instance.randStartingPos;
        if (flag == 0)
        rnd_l_choice = moving.instance.rnd_l_choice;
        else
        rnd_r_choice =moving.instance.rnd_r_choice;

        rnd = Random.Range(0,10);
        

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }

    void SpawnGem()
    {
            Instantiate(gem, new Vector3(transform.position.x,-1.15f,0), Quaternion.identity);
            rnd = 0;
    }
    void DestroyObject()
    {   
        if (PauseMenu.paused == false)
        {
            animator.SetTrigger("destroy");                    
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length+0.3f);
            gm.points += 1;
        }
        
    }

    private void Multi()
    {
        if (gameObject.tag == "Grag")
        Destroy (gameObject);
        else{
            if (transform.position.y >= -1.15f)
            transform.position -= new Vector3 (0, fallSpeed *Time.deltaTime,0);
            else {
                if (gameObject.tag == "Box"){
                    DestroyObject();
                }
                if (rnd >= 8)
                SpawnGem();
            
            }
        }
    }

    void Update()
    {   
        if (flag == 0)
        {
            if (transform.position.x <= rnd_l_choice)
            transform.position += new Vector3 (moveSpeed * Time.deltaTime,0,0);
            else{
                Multi();
            }
        }
        else
        {
            if (transform.position.x >= rnd_r_choice)
            transform.position -= new Vector3 (moveSpeed * Time.deltaTime,0,0);
            else{
                Multi();
            }
        } 
    }
    
    
}
