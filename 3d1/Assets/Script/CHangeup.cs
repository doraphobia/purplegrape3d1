using UnityEngine;

public class HideAndSpawnOnKeyPress : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectsToHide; // 需要隐藏的物体数组

    [SerializeField]
    GameObject objectToSpawn; // 需要生成的Prefab

    [SerializeField]
    KeyCode keyCode = KeyCode.Space; // 触发隐藏和生成的按键

   // bool isSpawned = false; // 追踪是否已经生成了对象
    bool isHidden = false;  // 追踪物体是否被隐藏

    void Update()
    {
        // 检查是否按下空格键
        if (Input.GetKeyDown(keyCode))
        {
            if (isHidden)
            {
                // 如果物体已经被隐藏，则显示它们并销毁生成的Prefab
                ShowObjects();
                DestroySpawnedObjects(); // 移除生成的Prefab
            }
            else
            {
                // 如果物体当前是可见的，则隐藏它们并在每个位置生成新的Prefab
                HideObjects();
                SpawnObjectsAtEachLocation(); // 在每个隐藏物体的位置生成Prefab
            }

            // 切换隐藏状态
            isHidden = !isHidden;
        }
    }

    // 隐藏 objectsToHide 数组中的所有物体
    void HideObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false); // 隐藏物体
            }
        }
    }

    // 显示 objectsToHide 数组中的所有物体
    void ShowObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(true); // 显示物体
            }
        }
    }

    // 在每个隐藏物体的位置生成Prefab
    void SpawnObjectsAtEachLocation()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null && objectToSpawn != null)
            {
                // 在每个隐藏物体的位置和旋转生成Prefab
                Instantiate(objectToSpawn, obj.transform.position, obj.transform.rotation);
            }
        }

       // isSpawned = true; // 标记已经生成了对象
    }

    // 销毁所有生成的Prefab
    void DestroySpawnedObjects()
    {
        // 找到所有带有 "SpawnedObject" 标签的对象
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");

        foreach (GameObject spawnedObject in spawnedObjects)
        {
            if (spawnedObject != null)
            {
                Destroy(spawnedObject); // 销毁生成的Prefab
            }
        }

       // isSpawned = false; // 重置生成状态
    }
}
