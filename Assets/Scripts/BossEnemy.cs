using Unity.VisualScripting;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    
    [SerializeField] private float SpeedNormalBullet = 20f;
    [SerializeField] private float SpeedCircleBullet = 10f;
    
    [SerializeField] private float hpValue = 100f;

    [SerializeField] private GameObject MiniEnemy;

    [SerializeField] private float SkillCooldown = 1.5f;
    private float nextSkillTime = 0f;
    
    [SerializeField] private Object usbPrefab;

    protected override void Update()
    {
        base.Update();
        if (Time.time >= nextSkillTime)
        {
            UseSkill();
        }
    }

    protected override void Die()
    {
        base.Die();
        Instantiate(usbPrefab, firePoint.position, firePoint.rotation);
    }

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

    private void ShootNormal()
    {
        if (player != null)
        {
            Vector2 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * SpeedNormalBullet);
        }
    }

    private void ShootCircle()
    {
        const int BulletCount = 12;
        float angleStep = 360 / BulletCount;
        for (int i = 0; i < BulletCount; i++)
        {
            float angle = angleStep * i;
            Vector3 BulletDirection =
                new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0f);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(BulletDirection * SpeedCircleBullet);
        }
    }

    private void Heal(float hpAmmount)
    {
        currentHp= Mathf.Min(currentHp + hpAmmount, maxHp);
        UpdateHpBar();
    }

    private void SummonMiniEnemy()
    {
        Instantiate(MiniEnemy, transform.position, Quaternion.identity);
    }

    private void Teleport()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }

    private void RamdomSkill()
    {
        int ramdomSkill = Random.Range(0, 5);
        switch (ramdomSkill)
        {
            case 0:
                ShootNormal();
                break;
            case 1:
                ShootCircle();
                break;
            case 2:
                Heal(hpValue);
                break;
            case 3:
                Teleport();
                break;
            case 4:
                SummonMiniEnemy();
                break;
        }
    }

    private void UseSkill()
    {
        nextSkillTime = Time.time + SkillCooldown;
        RamdomSkill();
    }
}