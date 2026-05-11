using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur
    public float speed = 3f;  // Vitesse de déplacement

    void Update()
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
}