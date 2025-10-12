using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float timeDestroy = 0.5f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private GameObject BloodPrefab;
    void Start()
    {
        Destroy(gameObject, timeDestroy);    
    }
    
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDame(damage);
                GameObject blood = Instantiate(BloodPrefab, transform.position, Quaternion.identity);
                Destroy(blood, 1f);
            }
            Destroy(gameObject);
        }
    }
}
