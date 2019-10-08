using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed;
    public Transform[] Points = new Transform[2];
    Rigidbody2D rbe;
    SpriteRenderer SPrenamy;
    bool OnRight;
    

    void Awake()
    {
        SPrenamy = GetComponent<SpriteRenderer>();
        rbe = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SPrenamy.flipX = OnRight;

        if (gameObject.transform.position.x < Points[0].position.x)
        {
            OnRight = true;
        }
        else if ((gameObject.transform.position.x > Points[1].position.x))
        {
            OnRight = false;
        }

        if (OnRight)
        {
            rbe.velocity = new Vector2(speed, rbe.velocity.y);
        }
        else
        {
            rbe.velocity = new Vector2(-speed, rbe.velocity.y);
        }
    }
}