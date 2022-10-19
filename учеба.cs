public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _speed;

    private float _runningTime;
    private float _targetMaxVolume = 1f;
    private float _targetMinVolume = 0f;

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
            StartCoroutine(FadeOff());
        }
    }

    private IEnumerator FadeIn()
    {
        _runningTime += Time.deltaTime;
        _audio.Play();

        for (int i = 0; i < 1000; i++)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetMaxVolume, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator FadeOff()
    {
        _runningTime += Time.deltaTime;

        for (int i = 0; i < 1000; i++)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetMinVolume, _speed * Time.deltaTime);

            if (_audio.volume < 0.1)
            {
                _audio.Stop();
            }
            yield return null;
        }
    }