using UnityEngine;
using UnityEngine.SceneManagement;

public class EntroVillageSwap : MonoBehaviour
{
    const string ENTROSCENE = "Entro Scene";
    const string VILLAGE = "Village";

    string sceneName;

    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name + "是当前场景");
        sceneName = SceneManager.GetActiveScene().name;
    }
    void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.activeSelf)
        {
            other.enabled = false;
        }

        if (sceneName == VILLAGE)
        Load(ENTROSCENE);
        if (sceneName == ENTROSCENE)
        Load(VILLAGE);
    }
}
