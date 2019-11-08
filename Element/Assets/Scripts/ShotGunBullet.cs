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
        Debug.Log(quaternion.x + "," + quaternion.y + "," + quaternion.z);
        Debug.Log(Quaternion.Euler(quaternion.x + Random.Range(-5, 5), quaternion.y + Random.Range(-5, 5), quaternion.z));

        //Quaternionでは変換が難しいためVector3に一時的に変換
        Vector3 vec = quaternion.eulerAngles;
        for (int i = 0; i < ShotAmm; i++)
        {
            //ここでQuaternionに戻す
            Instantiate(gameObject, vector3, Quaternion.Euler(vec.x + Random.Range(-5,5), vec.y + Random.Range(-5, 5), vec.z));
        }
    }
}