using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeZone : MonoBehaviour
{

    public bool right = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (right)
            {
                right = false;
                transform.position = new Vector2(transform.parent.transform.position.x - 1f, transform.position.y);
                
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!right)
            {
                right = true;
                transform.position = new Vector2(transform.parent.transform.position.x + 1f, transform.position.y);
            }
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
        }


    }
}
