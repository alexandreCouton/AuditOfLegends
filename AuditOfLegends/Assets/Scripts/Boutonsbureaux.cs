using UnityEngine;

public class Boutonsbureaux : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject boutonBureauEmployebasGauche;
    private GameObject boutonBureauEmployebasDroite;
    private GameObject boutonManager;
    private GameObject boutonChefProjet;
    private GameObject canvaManager;
    private GameObject canvaEmployeBasGauche;
    private GameObject canvaEmployeBasDroite;
    private GameObject canvaChefProjet;
    private GameObject map;


    void Start()
    {
        boutonBureauEmployebasGauche = GameObject.Find("ButtonEmpBasGaucheH");
        boutonBureauEmployebasDroite = GameObject.Find("ButtonEmpBasDroiteF");
        boutonManager = GameObject.Find("ButtonManager");
        boutonChefProjet = GameObject.Find("ButtonChefProjet");

        canvaManager = GameObject.Find("BureauManager");
        canvaEmployeBasGauche = GameObject.Find("BureauEmpM");
        canvaEmployeBasDroite = GameObject.Find("BureauEmpF");
        canvaChefProjet = GameObject.Find("BureauChefProjet");
        map = GameObject.Find("Map");
    }

    public void clickBoutonBureauEmployeBasGauche()
    {
        Debug.Log("Button Employee Bottom Left clicked");
        canvaEmployeBasGauche.enabled = true;
        map.SetActive(false);
    }
    public void clickBoutonBureauEmployeBasDroite()
    {
        Debug.Log("Button Employee Bottom Right clicked");
        canvaEmployeBasDroite.enabled = true;
        map.SetActive(false);
    }
    public void clickBoutonBureauManager()
    {
        Debug.Log("Button Manager clicked");
        canvaManager.enabled = true;
        map.SetActive(false);
    }
    public void clickBoutonBureauChefProjet()
    {
        Debug.Log("Button Project Manager clicked");
        canvaChefProjet.enabled = true;
        map.SetActive(false);
    }
    public void clickBoutonBureauFermer()
    {
        Debug.Log("Button Close clicked");
        canvaEmployeBasGauche.enabled = false;
        canvaEmployeBasDroite.enabled = false;
        canvaManager.enabled = false;
        canvaChefProjet.enabled = false;
        map.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
