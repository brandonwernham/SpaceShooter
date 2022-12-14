using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;

    // Some parameters to change in the inspector
    [Header("Set in Inspector")]
    public float speed = 30;
    public float rollMult = 45;
    public float pitchMult = 30;

    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        if (S == null) // Stores the hero field
        {
            S = this;
        } else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }

    private void Update()
    {
        // Getting the axis in order to move in both directions
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Moves the hero
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Rotates the hero
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        
        if (go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if (go.tag == "Enemy") // If hero hits an enemy, destroy both the enemy and hero
        {
            Destroy(go);
            Destroy(this.gameObject);
        } else
        {
            print("Triggered by non-Enemy: " + go.name);
        }
    }
}
