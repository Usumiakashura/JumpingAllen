using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;
    //public bool start;
    public float speed;

    void Start()
    {
        animator = GetComponent<Animator>();

        //animator.SetBool("isStart", true);
        transform.Translate(Vector2.right * speed);
    }

    private void FixedUpdate()
    {
        //if (start)
        //{
        //    GameObject.Find("TouchCube").GetComponent<Touch>().start = true;
        //    animator.SetBool("isStart", true);
        //    start = false;
        //}


        if (animator.GetBool("isStart"))
        {
            if (animator.GetBool("isMoveLeft"))
                transform.Translate(Vector2.left * speed);
            else
                transform.Translate(Vector2.right * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider2D>() != null)
        {
            if (animator.GetBool("isMoveLeft"))
                animator.SetBool("isMoveLeft", false);
            else animator.SetBool("isMoveLeft", true);
        }
    }
}
