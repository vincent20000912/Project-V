using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed=5f  ;
    private PlayerController playercs;
    //public ParticleSystem explosionParticle;
    //public int pointValue;
    private EnemyGenerate gameManager;
    private Rigidbody targetRb;
    private float xRange = 5;
    private float zSpawnPos = 78;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("God").GetComponent<EnemyGenerate>();
        playercs = GameObject.Find("Player").GetComponent<PlayerController>();
        transform.position = new Vector3(5*Random.Range(-xRange, xRange),0, zSpawnPos);

    }

    // Update is called once per frame
    void Update()
    {
        //destroy
        if (transform.position.z < -40)
        {
            Destroy(gameObject);
        }
        //gameover stop
        if (gameManager.isGameActive == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
        //move
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange),0, zSpawnPos);
    }
    //public void StartGame(int difficulty)

}
