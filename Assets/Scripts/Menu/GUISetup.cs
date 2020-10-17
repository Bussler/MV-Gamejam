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

    [SerializeField]
    Text MoveSpeed;
    [SerializeField]
    Text AttackDmg;
    [SerializeField]
    Text AttackRange;
    [SerializeField]
    Text AttackFreq;
    [SerializeField]
    Text ProjectileSpeed;

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
        if (ingameMenu.activeInHierarchy)
        {
            MoveSpeed.text = "Movement Speed: "+ StatManager.StatManagerInstance.GetPlayerSpeed();
            AttackDmg.text = "Attack Damage: " + StatManager.StatManagerInstance.GetAttackDamage();
            AttackRange.text = "Attack Range: " + StatManager.StatManagerInstance.GetProjectileLifetime();
            AttackFreq.text = "Attack Speed: " + (1-StatManager.StatManagerInstance.GetFireRate());
            ProjectileSpeed.text = "Projectile Speed: " + StatManager.StatManagerInstance.GetProjectileSpeed();
        }
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
