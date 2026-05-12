using UnityEngine;

public class slash : MonoBehaviour
{
    public Transform player;
    public float radius = 2.0f;
    private float timer;
    public float dureeActif;
    public float dureeInactif;
    private etat etatAttack = etat.inactif;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D boxCol;

    private void Start()
    {
        timer = 0f;     
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = (mousePos - player.position).normalized;
        transform.position = player.position + direction * radius;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);


        switch (etatAttack)
        {
            case etat.actif:
                timer += Time.deltaTime;
                if (timer > dureeActif)
                {
                    sprite.enabled=false;
                    boxCol.enabled = false;
                    etatAttack = etat.inactif;
                    timer = 0f;
                }
                break;

            case etat.inactif:
                timer += Time.deltaTime;
                if (timer > dureeInactif)
                {
                    sprite.enabled = true;
                    boxCol.enabled = true;
                    etatAttack = etat.actif;
                    timer = 0f;
                }
                break;
        } 


    }


    enum etat{

        actif,
        inactif

    }


    


}

