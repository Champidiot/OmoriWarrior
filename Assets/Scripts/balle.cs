using UnityEngine;

public class balle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;

    private float vitesseConstante = 50f;
    private float balleDamage = 10f;

    private Camera mainCamera;
    private float objectWidth;
    private float objectHeight;

    private int nombreDeRebonds = 0;
    public static int REBONDS_MAX = 2;

    private void Start()
    {
        mainCamera = Camera.main;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        objectWidth = sr.bounds.extents.x;
        objectHeight = sr.bounds.extents.y;

    }

    public void InitialiserVitesse(Vector2 direction, float vitesse)
    {
        rigi = GetComponent<Rigidbody2D>();

        vitesseConstante = vitesse;
        rigi.linearVelocity = direction * vitesseConstante;

        OrienterSprite();
    }

    private void Update()
    {
        CheckScreenBounds();
        OrienterSprite();
    }


    private void OrienterSprite()
    {
        if (rigi.linearVelocity != Vector2.zero)
        {
            
            float angle = Mathf.Atan2(rigi.linearVelocity.y, rigi.linearVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle+180, Vector3.forward);
        }
    }

    private void CheckScreenBounds()
    {
        
        Vector3 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Mathf.Abs(mainCamera.transform.position.z)));

        float minX = mainCamera.transform.position.x - (screenBounds.x - mainCamera.transform.position.x);
        float maxX = screenBounds.x;
        float minY = mainCamera.transform.position.y - (screenBounds.y - mainCamera.transform.position.y);
        float maxY = screenBounds.y;

        Vector3 viewPos = transform.position;
        bool aRebondi = false;

        if (viewPos.x - objectWidth < minX && rigi.linearVelocityX < 0)
        {
            rigi.linearVelocityX = Mathf.Abs(rigi.linearVelocityX);
            aRebondi = true;
        }
        else if (viewPos.x + objectWidth > maxX && rigi.linearVelocityX > 0)
        {
            rigi.linearVelocityX = -Mathf.Abs(rigi.linearVelocityX);
            aRebondi = true;
        }

        if (viewPos.y - objectHeight < minY && rigi.linearVelocityY < 0)
        {
            rigi.linearVelocityY = Mathf.Abs(rigi.linearVelocityY);
            aRebondi = true;
        }
        else if (viewPos.y + objectHeight > maxY && rigi.linearVelocityY > 0)
        {
            rigi.linearVelocityY = -Mathf.Abs(rigi.linearVelocityY);
            aRebondi = true;
        }

        if (aRebondi)
        {
            rigi.linearVelocity = rigi.linearVelocity.normalized * vitesseConstante;
            EnregistrerRebond();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            EnemyScript enemy = collision.GetComponent<EnemyScript>();

            if (enemy.nextDamageTime >= 0.13f)
            {
                enemy.EnemyHp1 -= balleDamage;
                enemy.TextDamage((int)balleDamage);
                enemy.nextDamageTime = 0f;
            }
        }
    }

    private void EnregistrerRebond()
    {
        nombreDeRebonds++;
        if (nombreDeRebonds >= REBONDS_MAX)
        {
            Destroy(gameObject);
        }
    }
}