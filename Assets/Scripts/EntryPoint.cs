using UnityEngine;
using Player;
using PlayerInput;
using Score;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private InputController inputController;

    [SerializeField]
    private ScoreView scoreView;

    private PlayerControllerPresenter playerPresenter;
    private ScoreViewPresenter scoreViewPresenter;
    void Start()
    {
        playerPresenter = new(player, inputController);
        scoreViewPresenter = new(new  ScoreModel(), scoreView);
    }

    private void OnDestroy()
    {
        playerPresenter.CallGameEnd();
        scoreViewPresenter.CallGameEnd();
    }
}
