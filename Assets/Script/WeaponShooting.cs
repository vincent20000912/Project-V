using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    public float Speed = 10f;
    public int pointValue;
    private EnemyGenerate gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("God").GetComponent<EnemyGenerate>();

    }

    // Update is called once per frame
    void Update()
    {
        //move
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        //Destroy
        if (transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.UpdateScore(pointValue);
            Destroy(collision.gameObject);
            //Debug.Log(gameObject.name + " was destroyed");
            Destroy(gameObject);
        }
    }
    
}
