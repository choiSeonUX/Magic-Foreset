using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectCharacter : MonoBehaviour
{
    private void Start()
    {
        PlayerData.selectNum = 0;
    }
    public void ClickBori()
    {
        PlayerData.selectNum = 1;
        SceneManager.LoadScene(1);
    }

    public void ClickCoco()
    {
        PlayerData.selectNum = 2;
        SceneManager.LoadScene(1);
    }
}
