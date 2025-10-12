
using UnityEngine;

public class EnergyEnemy : Enemy
{
    [SerializeField] private GameObject energyObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (player != null)
            {
                player.takeDame(enterDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDame(stayDamage);
            }
        }
    }

    protected override void Die()
    {
        if (energyObject != null)
        {
            GameObject energy = Instantiate(energyObject, transform.position, Quaternion.identity);
            Destroy(energy, 5f);
        }
        base.Die();
    }
}
