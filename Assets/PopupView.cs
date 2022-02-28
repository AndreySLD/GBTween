using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupView : MonoBehaviour
{
    [SerializeField]
    private Button _buttonClose;

    [SerializeField]
    private float _duration = 0.3f;

    [SerializeField]
    private Slider _slider;

    private bool _state;
    private void Start()
    {
        _buttonClose.onClick.AddListener(Hide);
    }
    private void OnDestroy()
    {
        _buttonClose.onClick.RemoveAllListeners();
    }
    public void Show()
    {
        if (_slider != null)
        {
            _duration = _slider.value;
        }

        gameObject.SetActive(true);
        _state = true;
        Animation(_state, _duration); 
    }
    public void Hide()
    {
        if (_slider != null)
        {
            _duration = _slider.value;
        }

        _state = false;
        Animation(_state, _duration);
    }
    private void Animation(bool state, float value)
    {
        var sequence = DOTween.Sequence();

        if (state)
        {            
            sequence.Insert(0.0f, transform.DOScale(Vector3.one, value));
            sequence.OnComplete(() =>
            {
                sequence = null;
            });
        }
        else
        {
            sequence.Insert(0.0f, transform.DOScale(Vector3.zero, value));
            sequence.OnComplete(() =>
            {
                sequence = null;
                gameObject.SetActive(false);
            });

        }
    }
}
