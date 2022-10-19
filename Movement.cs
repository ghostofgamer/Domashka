public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime*-1, 0, 0);
        }
    }
}
