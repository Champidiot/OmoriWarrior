using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur
    public float speed = 3f;  // Vitesse de déplacement

    public float EnemyHp1 = 20f;

    public float damageCooldown = 0.12f; 
    private float nextDamageTime = 0f;

    void Update()


    {
        VaVersPlayer();
        IsDead();
        
    }


    public float GiveEnemyHp()
    {
        return EnemyHp1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("couteau") && Time.time >= nextDamageTime)
        {
            EnemyHp1 -= 5;
            nextDamageTime = Time.time + damageCooldown;
        }
    }

    private void VaVersPlayer()
    {
        if (player != null)
        {
            // Déplace l'ennemi de sa position actuelle vers celle du joueur
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    private void IsDead()
    {
        if (EnemyHp1 <= 0)
        {
            Destroy(gameObject);
        }
    }
}