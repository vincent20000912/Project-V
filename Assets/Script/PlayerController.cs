using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed=10f ;
    private float HorizontalInput;
    public GameObject Weapon;
    public GameObject Player;
    public ParticleSystem run_particleLeft;
    public ParticleSystem run_particleRight;
    public ParticleSystem death_particle;

    private EnemyGenerate gameManager;
    private float xrange = 25f;
    // Start is called before the first frame update
    void Start()
    {
        run_particleLeft.Stop();
        run_particleRight.Stop();
        gameManager = GameObject.Find("God").GetComponent<EnemyGenerate>();
        transform.position = new Vector3(0, 0, -21.7f);
    }

    // Update is called once per frame
    void Update()
    {
        //Player Moving
        HorizontalInput = Input.GetAxis("Horizontal");
        if (gameManager.isGameActive == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed * -HorizontalInput);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Weapon, transform.position + new Vector3(0, 3.48f, 5), Weapon.transform.rotation);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                run_particleLeft.Play();

            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                run_particleLeft.Stop();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                run_particleRight.Play();
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                run_particleRight.Stop();
            }
            run_particleLeft.transform.position = Player.transform.position + new Vector3(3.04f, 0, 0);
            run_particleRight.transform.position = Player.transform.position + new Vector3(-3.04f, 0, 0);

            if (transform.position.x < -xrange)
            {
                transform.position = new Vector3(-xrange, 0, -21.7f);

            }
            else if (transform.position.x > xrange)
            {
                transform.position = new Vector3(xrange, 0, -21.7f);
            }
        }
        //Weapon shooting
        

        //partical run
        
       

    }
    //Gameover
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
            run_particleLeft.Stop();
            run_particleRight.Stop();
            death_particle.Play();
            death_particle.transform.position = Player.transform.position;

            
        }

    }
}
