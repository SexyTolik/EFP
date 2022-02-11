using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> LootObj = new List<GameObject>(); // пока ставить через едитор, в будущем можно реализовать загрузку из ресурсов
    [SerializeField] Button mLeft, mRight, rotate; // кнопки управления
    private GameObject currBlock;
    void Start()
    {
        SpawnBlock();
    }
    public void SpawnBlock()
    {
        currBlock = Instantiate(LootObj[Random.Range(0, LootObj.Count)], transform.position, Quaternion.identity);
        mLeft.onClick.RemoveAllListeners(); mRight.onClick.RemoveAllListeners();
        mLeft.onClick.AddListener(() => currBlock.GetComponent<Group>().Move(-1)); mRight.onClick.AddListener(() => currBlock.GetComponent<Group>().Move(1));
        rotate.onClick.AddListener(() => currBlock.GetComponent<Group>().Rotate());

    }
}
