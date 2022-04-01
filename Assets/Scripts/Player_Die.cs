using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Die : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public static int countLocal = 0;

    [SerializeField] private AudioSource DieSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.CompareTag("saw") || collision.gameObject.CompareTag("Die_Level"))
        {
           Die(); 
        }

        
    }

    private void Die()
    {
        countLocal++;
        anim.SetTrigger("PlayerDie");
        rb.bodyType = RigidbodyType2D.Static;
        DieSound.Play();
        DieCount();
    }
    public int DieCount()
    {
        if(countLocal>2)
        {
            countLocal = 0; 
            SceneManager.LoadScene("Retry"); 
        }
        return countLocal;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
