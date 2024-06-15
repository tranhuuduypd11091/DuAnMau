
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed = 2f;
    public int Hp = 50; // Số lượng HP tối đa của kẻ thù
    private int currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("IsRunning", true);
        currentHealth = Hp; // Khởi tạo HP hiện tại bằng HP tối đa
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            if (currentPoint == PointB.transform)
            {
                currentPoint = PointA.transform;
            }
            else
            {
                currentPoint = PointB.transform;
            }
            Flip();
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

    public void TakeDamage()
    {
        Hp -= 10;
        if (Hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       
        Destroy(gameObject);
    }
}