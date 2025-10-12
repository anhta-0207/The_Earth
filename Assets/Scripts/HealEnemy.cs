using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float healValue = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDame(stayDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDame(enterDamage);
            }
        }
    }

    protected override void Die()
    {
        healPlayer();
        base.Die();
    }

    private void healPlayer()
    {
        if (player != null)
        {
            player.heal(healValue);
        }
    }
}
