using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    const string VILLAGE = "Village";

    void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.activeSelf)
        {
            other.gameObject.SetActive(false);
        }
        Load(VILLAGE);
    }
}
