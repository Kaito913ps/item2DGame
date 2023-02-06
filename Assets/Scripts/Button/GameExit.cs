using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void ButtonExit()
    {
        Application.Quit();
        SoundManager.Instance.PlaySE(SESoundData.SE.TitleExit);
    }
}
