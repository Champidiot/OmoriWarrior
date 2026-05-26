using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [SerializeField] private AudioSource Ok;

    private float timer;

    private bool ClicTap = false;

    private void OnMouseDown()
    {
        if (!redMouse.IsOptionActivate)
        {
            Ok.Play();
            ClicTap = true;

            
        }
        
    }

    private void Update()
    {
        if(ClicTap == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.3)
            {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
    }

    private void Start()
    {
        ClicTap = false;
        timer = 0f;
    }
}
