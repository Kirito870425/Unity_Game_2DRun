using UnityEngine;
using UnityEngine.SceneManagement;


public class SceanControl : MonoBehaviour
{
    /// <summary>切換場景</summary>
    public void ChangScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>離開遊戲</summary>
    public void Quit()
    {
        Application.Quit();
    }

    //延遲呼叫方法 Invoke("Name", S)
    /// <summary>延遲切換場景</summary>
    public void DelayChangScene()
    {
        Invoke("ChangScene", 0.5f);
    }
}
