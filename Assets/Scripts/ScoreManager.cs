using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Using singleton patern
    // access from outside scripts, but modify only inside this one
    public static ScoreManager Instance { get; private set; }
    private int _overallScore=0;
    private int _currentLevelScore;
    private int _maxScoreLevel=0;
    private int _maxGameScore = 0;

    private void Awake()
    {
        // Keep this object even when we go to new scene or reseting this one 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        // Destroy duplicate gameobject
        else if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    
    public void SecureLevelScore()
    {
        _overallScore=_overallScore+_currentLevelScore;
    }
    
    public void AddCollectedItem(int itemValue)
    {
        _currentLevelScore=_currentLevelScore+itemValue;
    }

    public void ResetScores()
    {
        _overallScore = 0;
        _maxGameScore = 0;
        _maxScoreLevel = 0;
    }
    
    public int ReturnCurrentScore()
    {
        return _currentLevelScore;
    }
    
    public void ResetCurrentLevelScore()
    {
        _currentLevelScore=0;
    }
    
    public void UpdateMaxLevelScore(int maxCollected)
    {
        _maxScoreLevel = maxCollected;
    }
    
    public void UpdateMaxGameScore()
    {
        _maxGameScore = _maxGameScore+_maxScoreLevel;
    }

    public int ReturnOverallScore()
    {
        return _overallScore;
    }
    
    public int ReturnMaxGameScore()
    {
        return _maxGameScore;
    }
    
}
