using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{

    public GameObject Fruit;
    public GameObject FruitFirstHalf;
    public GameObject FruitSecondHalf;

    GameObject Half1;
    GameObject Half2;

    Rigidbody2D FruitRB;
    PolygonCollider2D FruitColl;
    SpriteRenderer FruitSpr;
    Animator FruitAnim;


    void Start()
    {
        FruitRB = Fruit.GetComponent<Rigidbody2D>();
        FruitColl = Fruit.GetComponent<PolygonCollider2D>();
        FruitSpr = Fruit.GetComponent<SpriteRenderer>();
        FruitAnim = Fruit.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Knife")){
            Half1 = GameObject.Instantiate(FruitFirstHalf);
            Half2 = GameObject.Instantiate(FruitSecondHalf);
            Half1.transform.localPosition = Fruit.transform.localPosition;
            Half2.transform.localPosition = Fruit.transform.localPosition; 
            Destroy(Fruit);
        }
    }

    void Update()
    {      
    }
}
