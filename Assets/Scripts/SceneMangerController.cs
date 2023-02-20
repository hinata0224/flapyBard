using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class SceneMangerController : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    [SerializeField]
    private Button sceneMoveButton;
    void Start()
    {
        sceneMoveButton.OnClickAsObservable()
            .Subscribe(_ => LoadScene(sceneName))
            .AddTo(this);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
