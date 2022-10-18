public class Signal : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private float _runningTime;
    private float _target = 1f;
    private float _volumeScale;

    private void Start()
    {
        _audio.volume = 0.01f;
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
        StartCoroutine(FadeOff());
    }

    private IEnumerator FadeIn()
    {
        _runningTime += Time.deltaTime;
        _volumeScale = _runningTime / _duration;
        _audio.Play();

        for (int i = 0; i < _duration; i++)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
            yield return null;
        }
    }

    private IEnumerator FadeOff()
    {
        _runningTime += Time.deltaTime;
        _volumeScale = _runningTime / _duration;
        _audio.Play();

        for (int i = 0; i < _duration; i++)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0f, _volumeScale);
            yield return null;
        }
    }