using UnityEngine;

public class YesButtonMenu : MonoBehaviour
{
    [SerializeField] private AudioSource Byebye;

    private float timer = 0f;

    private bool Quit=false;

    private void OnMouseDown()
    {
        Byebye.Play();
        Quit = true;

    }

    private void Update()
    {
        if (Quit)
        {
            timer += Time.deltaTime;
        }

        if (timer > 0.2)
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
