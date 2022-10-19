public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _speed;

    private float _targetMaxVolume = 1f;
    private float _targetMinVolume = 0f;
    private Coroutine _coroutine;

    private void Start()
    {
        _audio.volume = 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _coroutine =  StartCoroutine(FadeOff());
        }
    }

    private IEnumerator FadeIn()
    {
        _audio.Play();

        while (_audio.volume != _targetMaxVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetMaxVolume, _speed * Time.deltaTime);

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            yield return null;
        }
    }

    private IEnumerator FadeOff()
    {
        _audio.Play();

        while (_audio.volume != _targetMinVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetMinVolume, _speed * Time.deltaTime);
            yield return null;
        }
    }