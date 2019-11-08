using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : BulletBase
{
    private SphereCollider sphereCollider;
    [SerializeField]
    private int SlowSpeed;

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
            sphereCollider.radius += 0.07f;
            if (speed >= 0)
            {
                speed -= SlowSpeed;
            }
        }
    }

    public override void Shot(Vector3 vector3, Quaternion quaternion)
    {
        Ammunation--;
        Instantiate(gameObject, vector3, quaternion);
    }
}
