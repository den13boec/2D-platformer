using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Text endScore;
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Show final score
        endScore.text="Your score: " + ScoreManager.Instance.ReturnOverallScore() + " / " + ScoreManager.Instance.ReturnMaxGameScore();
    }
}
