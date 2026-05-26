using UnityEngine;

public class NoButtonMenu : MonoBehaviour
{

    [SerializeField] private AudioSource TurnBack;

    [SerializeField] private GameObject MenuOption;

    private float timer = 0f;

    private bool Quit = false;

    private void OnMouseDown()
    {
        if (redMouse.IsOptionActivate)
        {
            TurnBack.Play();

            Quit = true;

        }

    }

    private void Update()
    {
        if (Quit)
        {
            timer += Time.deltaTime;
        }

        if (timer > 0.2)
        {
            redMouse.IsOptionActivate = false;
            redMouse.QuelBouton = 0;
            timer = 0f;
            Quit = false;
            MenuOption.SetActive(false); 
        }
    }
}
