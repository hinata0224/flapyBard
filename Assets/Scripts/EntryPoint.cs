using UnityEngine;
using Player;
using PlayerInput;
using Score;
using GameOverUI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private InputController inputController;

    [SerializeField]
    private ScoreView scoreView;

    [SerializeField]
    private GameOverView gameOverView;

    private PlayerControllerPresenter playerPresenter;
    private ScoreViewPresenter scoreViewPresenter;
    private GameOverPresenter gameOverPresenter;
    void Start()
    {
        playerPresenter = new(player, inputController);
        scoreViewPresenter = new(new ScoreModel(), scoreView);
        gameOverPresenter = new(gameOverView);
    }

    private void OnDestroy()
    {
        playerPresenter.CallGameEnd();
        scoreViewPresenter.CallGameEnd();
    }
}
