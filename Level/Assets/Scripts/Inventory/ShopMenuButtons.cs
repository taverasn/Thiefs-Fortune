using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuButtons : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject playerInventory;
    ShopInventory shopInventory;
    Inventory inventory;

    private void Start()
    {
        shopInventory = ShopInventory.instance;
    }
    public void WhereAmI()
    {
        //dialogue.text = "Look around you! Paradise!";
    }

    public void Shop()
    {
        gameManager.instance.hint.SetActive(false);
        gameManager.instance.npcDialogue.SetActive(false);
        shopMenu.SetActive(true);
        playerInventory.SetActive(true);
    }

    public void Bye()
    {
        gameManager.instance.npcDialogue.SetActive(false);
        gameManager.instance.NpcUnpause();
        //dialogue.text = "What's that smell... Sniff Sniff... Huh I think that's me... Oh Hi! What can I do for you today?";
        gameManager.instance.mainCamera.SetActive(true);
        gameManager.instance.shopCam.SetActive(false);
    }

    public void BuyAmmo()
    {
        if (gameManager.instance.currencyNumber >= 2 && gameManager.instance.ammoCount != 5)
        {
            int ammoGone = 5 - gameManager.instance.playerScript.gunStats.ammoCount;

            if (ammoGone >= 1)
            {
                gameManager.instance.playerScript.gunStats.ammoCount = 5;
            }
            else
            {
                gameManager.instance.playerScript.gunStats.ammoCount += ammoGone;
            }

            gameManager.instance.currencyNumber -= 2;
            gameManager.instance.IncreaseAmmo();
        }
    }

    public void BuyHealth()
    {
        if (gameManager.instance.currencyNumber >= 2 && gameManager.instance.playerScript.HP < gameManager.instance.playerScript.HPOrig)
        {
            float healthGone = gameManager.instance.playerScript.HPOrig - gameManager.instance.playerScript.HP;

            if (healthGone >= (gameManager.instance.playerScript.HPOrig / 2))
            {
                gameManager.instance.playerScript.HP += (gameManager.instance.playerScript.HPOrig / 2);
            }
            else
            {
                gameManager.instance.playerScript.HP += healthGone;
                gameManager.instance.playerScript.lerpTime = 0f;
            }

            gameManager.instance.currencyNumber -= 2;
        }
    }

    public void NoBuy()
    {
        gameManager.instance.npcDialogue.SetActive(true);
        gameManager.instance.shopInventory.SetActive(false);
    }
}
