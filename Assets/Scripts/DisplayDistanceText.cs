using TMPro;
using UnityEngine;

public class DisplayDistanceText : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private Transform _playerTrans;

    private Vector2 _startPosition;

    void Start()
    {
        _startPosition = _playerTrans.position;
    }

    void Update()
    {
        Vector2 distance = (Vector2)_playerTrans.position - _startPosition;

        // ignore vertical movement
        distance.y = 0f;

        // prevent negative distance
        if (distance.x < 0)
            distance.x = 0;

        // display distance
        _distanceText.text = distance.x.ToString("F0") + " m";
    }
}