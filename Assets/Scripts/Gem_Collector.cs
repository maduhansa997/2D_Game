using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem_Collector : MonoBehaviour
{
    [SerializeField] private Text GemCount;
    [SerializeField] private AudioSource collectSound;
    private int gems = 0;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("gem"))
        {
            Destroy(collision.gameObject);
            gems++;
            GemCount.text = "Gems : "+gems;
            collectSound.Play();
        }
    }
}
