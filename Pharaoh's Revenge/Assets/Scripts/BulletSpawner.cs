using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    float timer = 0f;
    int direction = 1;
    bool right;


    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    void SpawnMe()
    {
        GameObject boolet = (GameObject)Instantiate(spawnPrefab, transform.position, transform.rotation);
        float xVel = 10 + direction*transform.GetComponent<Rigidbody2D>().velocity.x;
        boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction* xVel, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            timer += Time.deltaTime;
            if (timer > .3)
            {
                SpawnMe();
                timer = 0;
            }

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (right)
            {
                right = false;
                direction = -1;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!right)
            {
                right = true;
                direction = 1;
            }
        }
    }


}
