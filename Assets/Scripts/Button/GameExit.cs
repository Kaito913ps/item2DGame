using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameExit : MonoBehaviour
{
    public void ButtonExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
        SoundManager.Instance.PlaySE(SESoundData.SE.TitleExit);
    }
}
