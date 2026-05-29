using UnityEngine;

public class balle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;

    private Camera mainCamera;
    private float objectWidth;
    private float objectHeight;

    private void CheckScreenBounds()
    {
        Vector3 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Mathf.Abs(mainCamera.transform.position.z)));

        float minX = mainCamera.transform.position.x - (screenBounds.x - mainCamera.transform.position.x);
        float maxX = screenBounds.x;
        float minY = mainCamera.transform.position.y - (screenBounds.y - mainCamera.transform.position.y);
        float maxY = screenBounds.y;

        Vector3 viewPos = transform.position;

        if (viewPos.x - objectWidth < minX && rigi.linearVelocityX < 0)
        {
            rigi.linearVelocityX = Random.Range(SpeedMin, SpeedMax);
        }
        else if (viewPos.x + objectWidth > maxX && rigi.linearVelocityX > 0)
        {
            rigi.linearVelocityX = -Random.Range(SpeedMin, SpeedMax);
        }

        if (viewPos.y - objectHeight < minY && rigi.linearVelocityY < 0)
        {
            rigi.linearVelocityY = Random.Range(SpeedMin, SpeedMax);
        }
        else if (viewPos.y + objectHeight > maxY && rigi.linearVelocityY > 0)
        {
            rigi.linearVelocityY = -Random.Range(SpeedMin, SpeedMax);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            EnemyScript enemy = collision.GetComponent<EnemyScript>();

            if (enemy.nextDamageTime >= 0.13f)
            {
                enemy.EnemyHp1 -= melonDamage;
                enemy.nextDamageTime = 0f;
            }
            int axeAInverser = Random.Range(1, 3);

            if (axeAInverser == 1)
            {
                float directionActuelle = Mathf.Sign(rigi.linearVelocityX);
                rigi.linearVelocityX = -directionActuelle * Random.Range(SpeedMin, SpeedMax);
            }
            else
            {
                float directionActuelle = Mathf.Sign(rigi.linearVelocityY);
                rigi.linearVelocityY = -directionActuelle * Random.Range(SpeedMin, SpeedMax);
            }
        }
    }
}
