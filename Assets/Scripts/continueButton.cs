using UnityEngine;

public class continueButton : MonoBehaviour
{
    [SerializeField] private AudioSource Nope;

    private void OnMouseDown()
    {
        if (!redMouse.IsOptionActivate)
        {
            Nope.Play();
        }
        
    }
}
