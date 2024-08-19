using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int health = 50;
    public Transform player;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 플레이어를 향해 이동
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("몬스터 체력: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("몬스터가 죽었습니다!");
        Destroy(gameObject);
    }
}