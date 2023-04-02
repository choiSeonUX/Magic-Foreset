using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSelcetCharacter : MonoBehaviour
{
    [SerializeField] GameObject Bori;
    [SerializeField] GameObject Coco;
    private void Awake()
    {
        if (PlayerData.selectNum == 1)
        {
            Bori.SetActive(true);
            Coco.SetActive(false);
        }
        else if (PlayerData.selectNum == 2)
        {
            Bori.SetActive(false);
            Coco.SetActive(true);
        }
    }
}
