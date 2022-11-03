using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy // Inherits from the enemy superclass
{
    private float direction;

    void Start()
    {
        direction = Random.Range(0, 2); // This creates a random number either 0 or 1 that will determine the direction of enemy 2
    }

    public override void Move()
    {
        if (direction == 0) // If direction is 0, turn 45 degrees right and move diagonally
        {
            Vector3 rot = new Vector3(0, 0, 45);
            this.transform.rotation = Quaternion.Euler(rot);
            Vector3 tempPos = pos;
            tempPos.x += speed * Time.deltaTime;
            pos = tempPos;
        } else // If direction is 1, turn 45 degrees left and move diagonally
        {
            Vector3 rot = new Vector3(0, 0, -45);
            this.transform.rotation = Quaternion.Euler(rot);
            Vector3 tempPos = pos;
            tempPos.x -= speed * Time.deltaTime;
            pos = tempPos;
        }

        base.Move();
    }
}
