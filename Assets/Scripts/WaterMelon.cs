using UnityEngine;

public class WaterMelon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;

    public float dureeActif;
    public float dureeInactif;
    public float melonDamage = 10f;
    public int NiveauAme = 0;

    private Camera mainCamera;
    private float objectWidth;
    private float objectHeight;

    private float SpeedMin = 3f;
    private float SpeedMax = 5f;


    private Vector3 echelleOrigine;

    private void Awake()
    {
        echelleOrigine = transform.localScale;

        if (echelleOrigine == Vector3.zero)
        {
            echelleOrigine = new Vector3(2.27f, 2.27f, 2.27f);
        }

    }

    private void Start()
    {
        rigi.linearVelocityX = Random.Range(SpeedMin, SpeedMax);
        rigi.linearVelocityY = Random.Range(SpeedMin, SpeedMax);

        mainCamera = Camera.main;

        ActualiserTailleBordures();
    }

    private void Update()
    {
        CheckScreenBounds();
        Roll();
    }

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
                enemy.TextDamage((int)melonDamage);
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

    private void Roll()
    {
        float vitesseRotation = 300f;
        if (rigi.linearVelocityX > 0)
        {
            transform.Rotate(0, 0, -vitesseRotation * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, vitesseRotation * Time.deltaTime);
        }
    }

 

    public void Upgrade()
    {
        Vector3 baseScale = new Vector3(2.27f, 2.27f, 2.27f);

        switch (NiveauAme)
        {
            case 1:
                transform.localScale = baseScale;
                break;

            case 2:
                transform.localScale = baseScale * 1.5f;
                melonDamage = 10f;
                SpeedMin = 5f;
                SpeedMax = 7.5f;
                ActualiserTailleBordures();
                break;

            case 3:
                transform.localScale = baseScale * 2.3f;
                melonDamage = 30f;
                SpeedMin = 7.5f;
                SpeedMax = 10f;
                ActualiserTailleBordures();
                break;
        }
    }

    private void ActualiserTailleBordures()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        objectWidth = spriteRenderer.bounds.extents.x;
        objectHeight = spriteRenderer.bounds.extents.y;

    }
}