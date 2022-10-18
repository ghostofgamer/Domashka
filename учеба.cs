public class Signal : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;


    private float _runningTime;
    private float target = 3f;
    private float volumeScale;

    private void Start()
    {
        _audio.volume = 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _runningTime += Time.deltaTime;
        volumeScale = _runningTime / _duration;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(FadeIn());
            _audio.Play();
            //_audio.volume = Mathf.MoveTowards(_audio.volume,target, volumeScale);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _audio.Stop();
    }

    private IEnumerable FadeIn()
    {
        _runningTime = 0;
        _runningTime += Time.deltaTime;
        yield return null;
    }