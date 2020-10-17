using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GUISetup : MonoBehaviour
{

    public Text Nektar;

    public Image[] hearts;

    public Image[] sprints;

    public GameObject ingameMenu;

    // Start is called before the first frame update
    void Start()
    {
        Nektar.text = "Nectar: " + StatManager.StatManagerInstance.GetNectarAmount();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            showUnshowMenu();
        showHearts();
        showSprints();
        Nektar.text = "Nectar: " + StatManager.StatManagerInstance.GetNectarAmount();
    }

    public void showUnshowMenu()
    {
        ingameMenu.SetActive(!ingameMenu.activeInHierarchy);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void showHearts()
    {
        int numOfHearts = (int)StatManager.StatManagerInstance.GetLifePoints();

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void showSprints()
    {
        int numOfSprints = (int)StatManager.StatManagerInstance.GetNumberOfDashes();
        for (int i = 0; i < sprints.Length; i++)
        {
            if (i < numOfSprints)
            {
                sprints[i].enabled = true;
            }
            else
            {
                sprints[i].enabled = false;
            }
        }

    }

}
