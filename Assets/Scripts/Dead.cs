using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private GameObject buttons = null;
    private Animator animator = null;
    private float forceImpulse = 4f;
    //private bool isDead;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            animator.SetBool("isDead", true);
            GetComponent<Move>().speed = 0;
            GetComponent<Jump>().jumps = -1;
            if (transform.position.x < 0)
            {
                animator.SetBool("isMoveLeft", true);
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceImpulse, ForceMode2D.Impulse);
            }
            else
            {
                animator.SetBool("isMoveLeft", false);
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceImpulse, ForceMode2D.Impulse);
            }
            GetComponent<CoinsCalculate>().CalculateCoins();
            GetComponent<ScoreCalculate>().CalculateRecord();
            forceImpulse = 0f;
            buttons.GetComponent<ScrollUI>().onWindow = true;
        }
    }



}
