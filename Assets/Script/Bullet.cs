using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f; 
    Rigidbody2D myRigidbody;
    float xSpeed; 

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        CalculateBulletSpeed();
    }

    void Update()
    {
        
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    void CalculateBulletSpeed()
    {
        
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
           
            float direction = Mathf.Sign(player.transform.localScale.x);
            xSpeed = direction * bulletSpeed;
        }
        else
        {
            
            xSpeed = bulletSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           
            EnemyMovement enemy = other.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                enemy.TakeDamage(); 
            }

           
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
           
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      
        Destroy(gameObject);
    }
}
