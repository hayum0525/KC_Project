using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프래팸들을 보관할 변수들 2
    public GameObject[] prefabs;

    public int enemyCount = 0; // 적이 생성된 횟수를 추적

    // 리스폰 담당을 하는 리스트들 2
    public List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < prefabs.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 선택한 리스폰의 비활성화된 오브젝트에 접근하고, 그것을 발견하면 select 변수에 할당
        /*foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf) // 비활성화된 오브젝트를 찾습니다.
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }*/

        // 비활성화된 오브젝트가 없다면 새롭게 생성하여 select에 할당
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);

            if (index == 0 || index ==1 || index == 2 || index == 3) // 0 번 인덱스를 적(Enemy)로 가정
            {
                enemyCount++;
                //Debug.Log("enemy소환");
            }
        }

        return select;
    }
}
