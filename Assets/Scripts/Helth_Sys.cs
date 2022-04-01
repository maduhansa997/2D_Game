using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helth_Sys : MonoBehaviour
{
     [SerializeField] private Image Heart1;
    [SerializeField] private Image Heart2;
    [SerializeField] private Image Heart3;


    private static int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = Player_Die.countLocal;
        if(count == 1)
        {
            Destroy(Heart1);
        }
        else if(count == 2)
        {
            Destroy(Heart1);
            Destroy(Heart2);

        }
        else if(count == 3)
        {
            Destroy(Heart1);
            Destroy(Heart2);
            Destroy(Heart3);
        }
    }
}
