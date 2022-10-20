public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _speed ;

    private Coroutine _coroutine;
    private float _target;
    private float _startVolume = 0.1f;

    private void Start()
    {
        _audio.volume = _startVolume;
    }

    public void playAudio()
    {
        _audio.Play();
    }

    public void SignalOn()
    {
        _target = 1f;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(RegulateVolume(_target));
    }

    public void SignalOff()
    {
        _target = 0f;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(RegulateVolume(_target));
    }

    public IEnumerator RegulateVolume(float _target)
    {
        while (_audio.volume != _target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
