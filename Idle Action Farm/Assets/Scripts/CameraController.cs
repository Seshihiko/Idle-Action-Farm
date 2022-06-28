using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int distance;
    [SerializeField] private int speed;

    private void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y + distance, player.position.z - distance);
    }

    private void Update()
    {
            Vector3 _target = new Vector3(player.position.x, player.position.y + distance, player.position.z - distance);
            transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(player.position - transform.position),
                (speed / 2) * Time.deltaTime); //поворачвает в сторону игрока
    }
}
