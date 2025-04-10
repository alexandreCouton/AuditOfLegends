using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EmpSpriteUpdater : MonoBehaviour
{
    public Sprite sadFace;
    public Sprite neutralFace;
    public Sprite happyFace;
    private Person onePeople;
    public Image background;
    public int idPerson;
    [SerializeField] private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnButtonClicked();
    }

    // Update is called once per frame
    public void OnButtonClicked()
    {
        onePeople = gameManager.GetPerson(idPerson);
        float trust = onePeople.getTrustPercentage();
        if (trust < 33f)
        {
            background.sprite =sadFace;
        }
        else if (trust < 66f)
        {
            background.sprite = neutralFace;
        }
        else if (trust >= 66f)
        {
            background.sprite = happyFace;
        }

        Debug.Log($"Button Employee Bottom Left clicked : {trust}");
        
    }
}
