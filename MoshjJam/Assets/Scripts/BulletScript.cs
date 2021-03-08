using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 7f;
    public float maxDistance = 0;

    public Vector3 direction;


    // Methods
    public void SetDirection(Vector3 newDirection) 
    {
        direction = newDirection;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5) 
        {
            Destroy(this.gameObject);
        }
    }
}
