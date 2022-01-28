using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x > 200f)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 200f)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > 200f)
        {
            Destroy(gameObject);
        }
    }
}
