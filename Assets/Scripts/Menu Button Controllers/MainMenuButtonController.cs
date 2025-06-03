
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    void Update()
    {
        Debug.Log(FirstTimePlaying.FirstTime);
    }
    public void Play()
    {
        if (FirstTimePlaying.FirstTime)
        {
            SceneManager.LoadScene(2);
            FirstTimePlaying.FirstTime = false;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Quit(){
        Application.Quit();
    }
}
