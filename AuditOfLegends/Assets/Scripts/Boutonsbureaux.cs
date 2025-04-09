using UnityEngine;

public class Boutonsbureaux : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject boutonBureauEmployebasGauche;
    public GameObject boutonBureauEmployebasDroite;
    public GameObject boutonManager;
    public GameObject boutonChefProjet;
    public GameObject canvaManager;
    public GameObject canvaEmployeBasGauche;
    public GameObject canvaEmployeBasDroite;
    public GameObject canvaChefProjet;
    public GameObject map;


    void Start()
    {

    }

    public void clickBoutonBureauEmployeBasGauche()
    {
        Debug.Log("Button Employee Bottom Left clicked");
        canvaEmployeBasGauche.SetActive(true);
        map.SetActive(false);
    }
    public void clickBoutonBureauEmployeBasDroite()
    {
        Debug.Log("Button Employee Bottom Right clicked");
        canvaEmployeBasDroite.SetActive(true);
        map.SetActive(false);
    }
    public void clickBoutonBureauManager()
    {
        Debug.Log("Button Manager clicked");
        canvaManager.SetActive(true);
        map.SetActive(false);
    }
    public void clickBoutonBureauChefProjet()
    {
        Debug.Log("Button Project Manager clicked");
        canvaChefProjet.SetActive(true);
        map.SetActive(false);
    }
    public void clickBoutonBureauFermer()
    {
        Debug.Log("Button Close clicked");
        canvaEmployeBasGauche.SetActive(false);
        canvaEmployeBasDroite.SetActive(false);
        canvaManager.SetActive(false);
        canvaChefProjet.SetActive(false);
        map.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
