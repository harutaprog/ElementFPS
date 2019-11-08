using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    //弾丸を撃てない時間(ウェイトタイム)
    [SerializeField]
    protected float waitTime;
    //弾の速度
    [SerializeField]
    protected float speed;
    //残弾数
    private int Ammunation;
    //弾が消滅するまでの時間
    [SerializeField]
    private float deleteTime;
    protected Rigidbody rigidbody;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, deleteTime);
    }

    //弾を撃つ処理(継承先で処理を書く)
    public virtual void Shot(Vector3 vector3,Quaternion quaternion)
    {

    }

    //弾丸を増やす処理
    public void BulletAdd()
    {
        Ammunation++;
    }

    //弾丸の数を返す処理
    public int Amm_Get()
    {
        return Ammunation;
    }

    //弾丸の数を設定する処理
    public void Amm_Set(int amm)
    {
        Ammunation = amm;
    }

    //弾丸を撃てない時間(ウェイトタイム)を返す処理
    public float WaitTime_Check()
    {
        return waitTime;
    }

    //命中した時の処理(後で処理を書いてもよし)
    public virtual void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}