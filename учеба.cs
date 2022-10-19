public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _speed;

    private float _target;
    private float _targetMaxVolume = 1f;
    private float _targetMinVolume = 0f;
    private Coroutine _coroutine;

    private void Start()
    {
        _audio.volume = 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _target = 1f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _coroutine = StartCoroutine(RegulateVolume());

            //if (_coroutine != null)
            //{
            //    StopCoroutine(_coroutine);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _target = 0f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _coroutine = StartCoroutine(RegulateVolume());
        }
    }

    private IEnumerator RegulateVolume()
    {
        _audio.Play();

        while (_audio.volume != _target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _speed * Time.deltaTime);
            yield return null;
        }
    }