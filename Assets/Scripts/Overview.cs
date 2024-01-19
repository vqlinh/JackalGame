using UnityEngine;
using UnityEngine.SceneManagement;

public class Overview : MonoBehaviour
{
    [SerializeField] private float delayUntilNextScene = 5f;

    private void Start()
    {
        Invoke(nameof(LoadNextScene), delayUntilNextScene);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
