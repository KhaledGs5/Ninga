using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerColl : MonoBehaviour
{
    Rigidbody2D MixerCollRb;
    PolygonCollider2D MixerCollider;
    public Mixer Mx;


    void Start()
    {
        MixerCollRb = GetComponent<Rigidbody2D>();
        MixerCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Water1")) {
            Destroy(other.gameObject);
        }
        Mx.numberofwatermelon++;
        Debug.Log("Mixed WaterMelon : "+ Mx.numberofwatermelon);
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Water1") || other.gameObject.CompareTag("Water2")) {
            Destroy(other.gameObject);
        }
    }


    void Update()
    {
        
    }
}
