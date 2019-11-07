using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : BulletBase
{
    [SerializeField]
    private int ShotAmm;

    //弾丸の挙動を設定
    void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * speed * Time.deltaTime;
    }

    public override void Shot(Vector3 vector3, Quaternion quaternion)
    {
        for (int i = 0; i < ShotAmm; i++)
        {
            Instantiate(gameObject, vector3, new Quaternion(quaternion.x + Random.Range(-0.3f,0.3f), quaternion.y + Random.Range(-0.3f, 0.3f), quaternion.z, quaternion.w));
        }
    }
}