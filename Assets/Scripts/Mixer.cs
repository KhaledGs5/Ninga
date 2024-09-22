using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{

    Rigidbody2D MixerRb;
    Animator MixerAnim;

    public int numberofwatermelon = 0;

    void Start()
    {
        MixerRb = GetComponent<Rigidbody2D>();
        MixerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(numberofwatermelon >= 1 && numberofwatermelon <= 2){
            MixerAnim.SetInteger("State", 1);
        }else if(numberofwatermelon >= 3 && numberofwatermelon <= 4){
            MixerAnim.SetInteger("State", 2);
        }else if(numberofwatermelon >= 5 && numberofwatermelon <= 8){
            MixerAnim.SetInteger("State", 3);
        }else if(numberofwatermelon >= 9 && numberofwatermelon <= 10){
            MixerAnim.SetInteger("State", 4);
        }else{
            MixerAnim.SetInteger("State", 5);
        }
    }
}
