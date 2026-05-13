using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f; 

    public float EnemyHp1 = 20f;

    public float damageCooldown = 0.12f; 
    private float nextDamageTime = 0f;
    private float nextHeroDamageTime = 0f;
    public float damageHeroCooldown = 0.12f;


    [SerializeField] private Rigidbody2D rbEnemy;

    void Update()


    {
        
        IsDead();
        
    }

    private void FixedUpdate()
    {
        VaVersPlayer();
    }


    public float GiveEnemyHp()
    {
        return EnemyHp1;
    }

   

    private void VaVersPlayer()
    {    

            Vector2 direction = (player.position - transform.position);

            direction.Normalize();

            rbEnemy.linearVelocity = direction * speed;        
        
    }

    private void IsDead()
    {
        if (EnemyHp1 <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("couteau") && Time.time >= nextDamageTime)
        {
            EnemyHp1 -= 5;
            nextDamageTime = Time.time + damageCooldown;
        }

        if (collision.gameObject.CompareTag("joueur") && Time.time >= nextHeroDamageTime)
        {
            PlayerScript playerScri = collision.gameObject.GetComponent<PlayerScript>();

            playerScri.HeroHp -= 5;
            nextHeroDamageTime = Time.time + damageHeroCooldown;
        }


    }

}