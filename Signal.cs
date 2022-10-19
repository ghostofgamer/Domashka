public class Signal : MonoBehaviour
{
    private float _target;
    private Coroutine _coroutine; 
    [SerializeField] private SpriteRenderer _house;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _house.GetComponent<ChangeVolume>().playAudio();
        _target = 1f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(_house.GetComponent<ChangeVolume>().RegulateVolume(_target));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _target = 0f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(_house.GetComponent<ChangeVolume>().RegulateVolume(_target));
        }
    }
}
