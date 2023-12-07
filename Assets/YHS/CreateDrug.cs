using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDrug : MonoBehaviour
{
    public GameObject cannabis;
    public GameObject heroin;
    public GameObject cocain;
    public GameObject pentanill;
    public GameObject lsd;
    public GameObject philopon;

    public void cannabis_Create()
    {
        cannabis.SetActive(true);
    }

    public void heroin_Create()
    {
        heroin.SetActive(true);
    }

    public void cocain_Create()
    {
        cocain.SetActive(true);
    }

    public void pentanill_Create()
    {
        pentanill.SetActive(true);
    }

    public void lsd_Create()
    {
        lsd.SetActive(true);
    }

    public void philopon_Create()
    {
        philopon.SetActive(true);
    }
}
