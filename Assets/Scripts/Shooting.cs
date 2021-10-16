using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Shooting : NetworkBehaviour
{
    public GameObject bullet;
    public float force;

    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject NewBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                Physics.IgnoreCollision(NewBullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
                Ray ray = new Ray();
                
                Vector3 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                ray.origin = gameObject.transform.position;
                ray.direction = Direction;
                NewBullet.GetComponent<Rigidbody>().AddForce(ray.direction * force);
            }
        }
    }
}
