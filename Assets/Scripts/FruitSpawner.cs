using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject Fruit;
    
    private GameObject SpawnedFruit;

    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine() {
        while (true) {
            SpawnedFruit = GameObject.Instantiate(Fruit);
            Rigidbody2D SpawnedFruitRB = SpawnedFruit.GetComponent<Rigidbody2D>();
            int pos = Random.Range(4,8);
            SpawnedFruit.transform.localPosition = gameObject.transform.position + new Vector3(0, pos ,0);
            int frc = Random.Range(17,20);
            SpawnedFruitRB.AddForce(new Vector3(-frc, frc/2 ,0), ForceMode2D.Impulse);
            yield return new WaitForSeconds(Random.Range(1,3));
        }
    }

    void Update()
    {
        
    }   
}
