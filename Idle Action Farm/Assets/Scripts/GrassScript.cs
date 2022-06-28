using UnityEngine;

public class GrassScript : MonoBehaviour
{
    [HideInInspector] public SpawnGrass spawner; //������ ��������. ����� ��� �� ��� �������� ������������� ������� ������� �����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            Instantiate(DataManager.dropdownParticle, transform.position, Quaternion.identity);

            Instantiate(DataManager.dropdownItem, new Vector3(transform.position.x,
                transform.position.y + 1, transform.position.z), Quaternion.identity);

            spawner.StartTimer();

            Destroy(gameObject);
        }
    }
}
