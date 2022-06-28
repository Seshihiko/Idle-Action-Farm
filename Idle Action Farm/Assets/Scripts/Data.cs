using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "data/Item Data")]
public class Data : ScriptableObject
{
    [SerializeField] private float _timeToSpawn; //Время до спавна
    [SerializeField] private int _price; //Цена за элемент
    [SerializeField] private int _maxCountOfItem; //Максимальная вместимость в один стак 
    [SerializeField] private GameObject _dropdownItem; //Выпадающий элемент, куб
    [SerializeField] private GameObject _dropdownParticle; //Выпадающие частицы при срезании 
    [SerializeField] private GameObject _itemPrefab; //Префаб который спавнится на сцене

    public float timeToSpawn => _timeToSpawn;
    public int price => _price;
    public int maxCountOfItem => _maxCountOfItem;
    public GameObject dropdownItem => _dropdownItem;
    public GameObject dropdownParticle => _dropdownParticle;
    public GameObject itemPrafab => _itemPrefab;
}
