using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D col)
    {
        Score.scoreAmount += 10;
        Destroy(gameObject);
    }
 
}
