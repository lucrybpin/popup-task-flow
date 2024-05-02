using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] private Popup _popupPrefab;
    [SerializeField] private Button _buttonOpen;

    private void Awake()
    {
        _buttonOpen.onClick.AddListener(OnButtonOpenClick);
    }

    public async  void OnButtonOpenClick()
    {
        Popup popup = Instantiate(_popupPrefab);
        PopupAnswer answer = await popup.Show(this.transform);      // "Take the control and give me back when you get the answer" 

        Debug.Log("Answer: " + answer);
    }
}
