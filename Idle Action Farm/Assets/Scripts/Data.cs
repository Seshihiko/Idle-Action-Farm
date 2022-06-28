using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "data/Item Data")]
public class Data : ScriptableObject
{
    [SerializeField] private float _timeToSpawn; //����� �� ������
    [SerializeField] private int _price; //���� �� �������
    [SerializeField] private int _maxCountOfItem; //������������ ����������� � ���� ���� 
    [SerializeField] private GameObject _dropdownItem; //���������� �������, ���
    [SerializeField] private GameObject _dropdownParticle; //���������� ������� ��� �������� 
    [SerializeField] private GameObject _itemPrefab; //������ ������� ��������� �� �����

    public float timeToSpawn => _timeToSpawn;
    public int price => _price;
    public int maxCountOfItem => _maxCountOfItem;
    public GameObject dropdownItem => _dropdownItem;
    public GameObject dropdownParticle => _dropdownParticle;
    public GameObject itemPrafab => _itemPrefab;
}
