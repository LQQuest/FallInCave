using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public Transform player;
    [SerializeField]
    private float speed = 4.5f;
    
    void OnMouseDrag()
    {
        if (!Player.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if ((mousePos.x>player.position.x && player.localScale.x<0) || (mousePos.x <player.position.x && player.localScale.x>0))
            {
                player.localScale = new Vector3 (-player.localScale.x,player.localScale.y,player.localScale.z);
            }
            mousePos.x = mousePos.x > 0.55f ? 0.55f : mousePos.x;
            mousePos.x = mousePos.x < -0.55f ? -0.55f : mousePos.x;
            player.position = Vector2.MoveTowards (player.position, 
                new Vector2 (mousePos.x,player.position.y),
                speed* Time.deltaTime);
            

            
        }
        
    }
}
