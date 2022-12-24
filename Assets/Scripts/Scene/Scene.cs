using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField] string _chngeScene;
   
    public void LoadScenes()
    {
        Debug.Log($"Scene");
        SceneManager.LoadScene(_chngeScene);
    }
}
