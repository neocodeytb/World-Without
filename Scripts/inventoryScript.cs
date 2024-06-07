using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    public GameObject inventory;
    public NinjaScript ninja;
    public AudioSource opener;

    void Awake()
    {
        inventory.SetActive(false);
    }

    public void OpenInventory()
    {
        if (ninja.inInventory == false)
        {
            inventory.SetActive(true);
            ninja.inInventory = true;
            opener.Play();
        }

        else
        {
            inventory.SetActive(false);
            ninja.inInventory = false;
            opener.Play();

        }

    }
}
