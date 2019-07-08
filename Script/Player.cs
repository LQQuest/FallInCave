using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool lose = false;
    
    


    private Animator animator;
    private GameMaster gm;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    void Update()
    {
        bool walkButton = Input.GetKey(KeyCode.Mouse0);
        bool walkButtonDown = Input.GetKeyDown(KeyCode.Mouse0);
        if (walkButton)
        {
            animator.SetTrigger("Walk");
        }
        if (walkButtonDown)
        {
            animator.SetTrigger("Idle");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            lose = true;
            animator.SetTrigger("Dead");
        }

        if (other.gameObject.tag == "Gem")
        {
            Destroy(other.gameObject);
            gm.points += 100;   
        }
    }

}
