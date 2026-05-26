using UnityEngine;

public class redhandpause : MonoBehaviour
{
    public static int QuelBouton = 0;

    [SerializeField] private Transform Trans;

    [SerializeField] private SpriteRenderer SpRen;
    void Update()
    {

        switch (QuelBouton)
        {

            default:

                Trans.position = new Vector3(100, 100, 0);
                SpRen.enabled = false;
                break;

            case 1:
                Trans.position = new Vector3(-1.47f, -1f, -5.54f);
                SpRen.enabled = true;
                break;

            case 2:
                Trans.position = new Vector3(-1.47f, -2.35f, -5.54f);
                SpRen.enabled = true;
                break;

        }
    }
}
