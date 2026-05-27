using UnityEngine;

public class SolInfini : MonoBehaviour
{
    [SerializeField] private Transform joueur;

    private Vector2 tailleSprite;

    private Vector3 positionInitiale;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        tailleSprite = sr.bounds.size/3;
        positionInitiale = transform.position;
    }

    void LateUpdate()
    {

        float tailleX = Mathf.Round((joueur.position.x - positionInitiale.x) / tailleSprite.x);
        float tailleY = Mathf.Round((joueur.position.y - positionInitiale.y) / tailleSprite.y);

        transform.position = new Vector3(positionInitiale.x + (tailleX * tailleSprite.x),positionInitiale.y + (tailleY * tailleSprite.y),transform.position.z);
    }
}