using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;

    private float _currentFuelAmount;
    private bool _isEmpty = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    void Update()
    {
        if (_isEmpty)
            return;

        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        _currentFuelAmount = Mathf.Clamp(_currentFuelAmount, 0f, _maxFuelAmount);

        if (_currentFuelAmount <= 0f)
        {
            _isEmpty = true;
            GameManager.instance.GameOver();
        }

        UpdateUI();
    }

    public void FillFuel()
    {
        _currentFuelAmount = _maxFuelAmount;
        _isEmpty = false;
        UpdateUI();
    }

    void UpdateUI()
    {
        float fuelPercent = _currentFuelAmount / _maxFuelAmount;

        _fuelImage.fillAmount = fuelPercent;
        _fuelImage.color = _fuelGradient.Evaluate(fuelPercent);
    }
}