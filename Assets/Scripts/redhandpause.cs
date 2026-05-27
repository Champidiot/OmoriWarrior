using UnityEngine;
using UnityEngine.UI;

public class redhandpause : MonoBehaviour
{
    public static int QuelBouton = 0;

    [SerializeField] private RectTransform Trans;

    [SerializeField] private Image SpRen;
    void Update()
    {

        switch (QuelBouton)
        {

            default:

                SpRen.enabled = false;
                break;

            case 1:
                Trans.anchoredPosition = new Vector2(-236f, -1.4f);
                SpRen.enabled = true;
                break;

            case 2:
                Trans.anchoredPosition = new Vector2(-236f, -200f);
                SpRen.enabled = true;
                break;

        }
    }
}
