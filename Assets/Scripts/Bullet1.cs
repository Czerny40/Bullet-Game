using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{   
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            PlayerController.life -= 1;
            Destroy(this.gameObject);
            
            if (PlayerController.life == 0)
            {
                if(playerController != null)
                {
                    playerController.Die();
                }
            }
        }
        else if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
