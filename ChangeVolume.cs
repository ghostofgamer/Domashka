public class ChangeVolume : MonoBehaviour
{
    private float _speed = 0.5f;
    private float _target;
    private float _startVolume = 0.1f;
    [SerializeField] private AudioSource _audio;

    private void Start()
    {
        _audio.volume = _startVolume;
    }

    public void playAudio()
    {
        _audio.Play();
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
