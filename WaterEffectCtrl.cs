using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffectCtrl : MonoBehaviour
{

    public ParticleSystem WaterEffect;

    // 前の発生から1秒以上経過しないとエフェクト発生しない（1度に1回分だけ発生させる）
    public float IntervalTime = 1.0f;
    public float CurrentIntervalTime;

    // 水中フラグ
    public bool inWater = true;
    
    void Start()
    {
        CurrentIntervalTime = 0;
    }
    
    void Update()
    {
        // 水しぶき発生
        CurrentIntervalTime += 1 * Time.deltaTime;
    }

    // 水面から出たとき
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ocean")
        {
            if (CurrentIntervalTime > IntervalTime)
            {
                // 水しぶき発生
                var we = Instantiate(WaterEffect.gameObject, transform.position + Vector3.up * 1f, Quaternion.identity);
                Destroy(we, WaterEffect.startLifetime);

                CurrentIntervalTime = 0;
            }
            // 水中フラグをOFF
            inWater = false;
        }
    }

    // 水面に入るとき
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ocean")
        {
            if (CurrentIntervalTime > IntervalTime)
            {
                // 水しぶき発生
                var we = Instantiate(WaterEffect.gameObject, transform.position + Vector3.up * 1f, Quaternion.identity);
                Destroy(we, WaterEffect.startLifetime);

                CurrentIntervalTime = 0;
            }
            // 水中フラグをON
            inWater = true;
        }
    }
}
