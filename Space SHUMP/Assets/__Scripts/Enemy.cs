using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // The superclass for enemy
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;

    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>(); // Checks if the enemy is on or off screen
    }

    public Vector3 pos // The position of the enemy
    {
        get
        {
            return (this.transform.position);
        } set
        {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();

        // All of the below statements in the method check if the enemy went off the bottom, left, or right of the screen so they get destroyed when off screen
        if (bndCheck != null && bndCheck.offDown)
        {
            if (pos.y < bndCheck.camHeight - bndCheck.radius)
            {
                Destroy(gameObject);
            }
        }

        if (bndCheck != null && bndCheck.offLeft)
        {
            if (pos.x < bndCheck.camWidth - bndCheck.radius)
            {
                Destroy(gameObject);
            }
        }

        if (bndCheck != null && bndCheck.offRight)
        {
            if (pos.x > bndCheck.camWidth - bndCheck.radius)
            {
                Destroy(gameObject);
            }
        }
    }

    public virtual void Move() // Moves the enemy down
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
