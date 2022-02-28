using UnityEngine;
using UnityEngine.UI;

public class MainWindowView : MonoBehaviour
{
    [SerializeField]
    private Button _buttonOpenPopup;

    [SerializeField]
    private PopupView _popupView;


    private void Start()
    {
        _buttonOpenPopup.onClick.AddListener(_popupView.Show);
    }

    private void OnDestroy()
    {
        _buttonOpenPopup.onClick.RemoveAllListeners();
    }
}   
