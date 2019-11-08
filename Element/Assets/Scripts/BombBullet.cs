using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : BulletBase
{
    public override void Start()
    {
        base.Start();
        rigidbody.AddForce(transform.forward * 15, ForceMode.Impulse);
    }
    //弾丸の挙動を設定
    /*    void FixedUpdate()
        {
            rigidbody.velocity = transform.forward * speed * Time.deltaTime;
        }
    */
    public override void Shot(Vector3 vector3, Quaternion quaternion)
    {
        Instantiate(gameObject, vector3, quaternion);
    }
}
