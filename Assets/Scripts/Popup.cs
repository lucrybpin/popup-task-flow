using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public enum PopupAnswer
{
    No,
    Yes
}

public class Popup : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private TaskCompletionSource<PopupAnswer> _taskCompletionSource;

    public Task<PopupAnswer> Show(Transform parent)
    {
        //Just a normal Setup
        transform.SetParent(parent, false);
        _noButton.onClick.AddListener(OnNoClicked);
        _yesButton.onClick.AddListener(OnYesClicked);

        _taskCompletionSource = new TaskCompletionSource<PopupAnswer>();    // wait until taskComlpetion is Set to proceed to run the code below

        return _taskCompletionSource.Task;                                  // "Hey caller, here is the answer! Now take the control back"
    }

    private void OnNoClicked()
    {
        _taskCompletionSource.SetResult(PopupAnswer.No);
        Destroy(gameObject);
    }

    private void OnYesClicked()
    {
        _taskCompletionSource.SetResult(PopupAnswer.Yes);
        Destroy(gameObject);
    }

}
