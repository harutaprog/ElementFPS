using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : BulletBase
{
    private SphereCollider sphereCollider;

    public override void Start()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        base.Start();
    }

    //弾丸の挙動を設定
    void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * speed * Time.deltaTime;
        if (sphereCollider.radius < 2.0f)
        {
            sphereCollider.radius += 0.05f;
        }
    }

    public override void Shot(Vector3 vector3, Quaternion quaternion)
    {
        Instantiate(gameObject, vector3, quaternion);
    }
}
