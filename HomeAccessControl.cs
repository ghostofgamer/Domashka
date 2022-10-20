public class HomeAccessControl : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _signaling.playAudio();

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signaling.SignalOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signaling.SignalOff();
        }
    }
}
