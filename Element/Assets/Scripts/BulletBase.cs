using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField]
    protected float waitTime;
    [SerializeField]
    protected float speed;
    private int Ammunation;
    [SerializeField]
    private float deleteTime;
    protected Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
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
    public int Amm_Check()
    {
        return Ammunation;
    }

    //ウェイトタイムを返す処理
    public float WaitTime_Check()
    {
        return waitTime;
    }
}