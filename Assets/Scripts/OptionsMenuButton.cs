using UnityEngine;

public class OptionsMenuButton : MonoBehaviour
{
    [SerializeField] private AudioSource Jsp;

    [SerializeField] private GameObject OptionMenu;

    private void OnMouseDown()
    {
        if (!redMouse.IsOptionActivate)
        {
            Jsp.Play();
            redMouse.IsOptionActivate = true;
            OptionMenu.SetActive(true);
        }
        
    }
}
