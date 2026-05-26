using UnityEngine;

public class MouseOverBoutonHome : MonoBehaviour
{

    [SerializeField] private int BoutonNumbre;

    [SerializeField] private AudioSource son;
    private void OnMouseEnter()
    {
        if (BoutonNumbre < 4)
        {
            if (!redMouse.IsOptionActivate)
            {
                redMouse.QuelBouton = BoutonNumbre;
                son.Play();
            }
        }

        else
        {
            if (redMouse.IsOptionActivate)
            {
                redMouse.QuelBouton = BoutonNumbre;
                son.Play();
            }
        }
        
    }
}
