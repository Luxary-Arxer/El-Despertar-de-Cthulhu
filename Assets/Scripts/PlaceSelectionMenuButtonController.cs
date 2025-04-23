
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceSelectionMenuButtonController : MonoBehaviour
{
    public void GoToManor()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToGarden()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToLibrary()
    {
        SceneManager.LoadScene(4);
    }
}
