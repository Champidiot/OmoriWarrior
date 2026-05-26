using UnityEngine;

public class redMouse : MonoBehaviour
{
    public static int QuelBouton;

    [SerializeField] private Transform Trans;

    public static bool IsOptionActivate = false;
    void Update()
    {
        
        switch (QuelBouton)
        {

            default:

                Trans.position = new Vector3(100, 100, 0);
                break;

            case 1:
                Trans.position = new Vector3( -5.05f , -4.428f, -0.71f);
                break;

            case 2:
                Trans.position = new Vector3(-1.63f, -4.428f, -0.71f);
                break;

            case 3:
                Trans.position = new Vector3(1.72f, -4.428f, -0.71f);
                break;

            case 4:
                Trans.position = new Vector3(-1.81f, -0.68f, -0.71f);
                break;

            case 5:
                Trans.position = new Vector3(0.13f, -0.68f, -0.71f);
                break;

        }

        Debug.Log(IsOptionActivate);

    }
}
