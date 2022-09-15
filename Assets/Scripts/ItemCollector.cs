using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int _cherryValue = 1;
    //private int _currentScore;
    private int _colItemsCount;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioClip collectionSoundEffect;
    [SerializeField] private GameObject colItems;

    // Start because we need to awake() in scoreManager to set score level first
    private void Start()
    {
        // Count child objects of collectables
        var chCount = colItems.transform.childCount;
        cherriesText.text="Cherries: 0 / " + chCount;
        _colItemsCount = chCount;
        // Reset current level score
        ScoreManager.Instance.ResetCurrentLevelScore();
        ScoreManager.Instance.UpdateMaxLevelScore(_colItemsCount);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collided object has tag of collectable item (cherry)
        if (!collision.gameObject.CompareTag("Cherry")) return;
        Destroy(collision.gameObject);
        //_collectedCherries++;
        //cherriesText.text = "Cherries: " + _collectedCherries;
        //collectionSoundEffect.Play();
        SoundManager.Instance.PlaySound(collectionSoundEffect);
        ScoreManager.Instance.AddCollectedItem(_cherryValue);
        //_currentScore=ScoreManager.Instance.ReturnCurrentScore();
        // Showing player's score
        cherriesText.text = "Cherries: " + ScoreManager.Instance.ReturnCurrentScore() + " / " + _colItemsCount;
    }
}
