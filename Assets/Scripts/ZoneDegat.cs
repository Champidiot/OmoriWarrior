using UnityEngine;

public class ZoneDegat : MonoBehaviour
{
    public float zoneDamage = 1f;

    private float timerDamage;

    private float intervalDamage = 0.2f;

    private void Update()
    {
        timerDamage += Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(timerDamage >= intervalDamage)
        {

            if (collision.CompareTag("enemy"))
            {
                EnemyScript enemy = collision.GetComponent<EnemyScript>();


                if (enemy.nextDamageTime >= 0.13f)
                {
                    enemy.EnemyHp1 -= zoneDamage;

                    enemy.nextDamageTime = 0f;

                    timerDamage = 0f;
                }

            }

        }

        
    }
}
