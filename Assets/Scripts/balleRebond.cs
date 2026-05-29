using UnityEngine;

public class balleRebond : MonoBehaviour
{
    [SerializeField] private GameObject ballePrefab;
    [SerializeField] private float Cooldown = 0.5f;
    [SerializeField] private Transform playertrans;

    

    private float vitesseBalle = 50f;
    private float timerballe = 0f;

    public int NiveauAme = 0;

    private void Update()
    {
        if (NiveauAme > 0)
        {
            timerballe += Time.deltaTime;
            GenererBalle();
        }
        
    }

    private void GenererBalle()
    {
        if (timerballe >= Cooldown)
        {
            timerballe = 0f;

            
            Vector3 pointDeDepart = playertrans.position;

            Vector3 positionSourisEcran = Input.mousePosition;
            
            positionSourisEcran.z = Mathf.Abs(Camera.main.transform.position.z);
            Vector3 positionSourisMonde = Camera.main.ScreenToWorldPoint(positionSourisEcran);
            positionSourisMonde.z = pointDeDepart.z;
            Vector2 direction = ((Vector2)positionSourisMonde - (Vector2)pointDeDepart).normalized;

            
            GameObject nouvelleBalle = Instantiate(ballePrefab, pointDeDepart, Quaternion.identity);
            nouvelleBalle.SetActive(true);

            nouvelleBalle.transform.localScale = ballePrefab.transform.localScale;

            balle scriptBalle = nouvelleBalle.GetComponent<balle>();
            
            scriptBalle.InitialiserVitesse(direction, vitesseBalle);
            

        }
    }


    public void Upgrade()
    {
        switch (NiveauAme)
        {
            case 0:
                Cooldown = 2f;
                balle.REBONDS_MAX = 2;
                break;

            case 1:
                Cooldown = 0.8f;
                balle.REBONDS_MAX = 4;
                break;

            case 2:
                Cooldown = 0.4f;
                balle.REBONDS_MAX = 6;
                break;
        }
    }
}