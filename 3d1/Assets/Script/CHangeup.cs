using UnityEngine;

public class HideAndSpawnOnKeyPress : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectsToHide; // ��Ҫ���ص���������

    [SerializeField]
    GameObject objectToSpawn; // ��Ҫ���ɵ�Prefab

    [SerializeField]
    KeyCode keyCode = KeyCode.Space; // �������غ����ɵİ���

   // bool isSpawned = false; // ׷���Ƿ��Ѿ������˶���
    bool isHidden = false;  // ׷�������Ƿ�����

    void Update()
    {
        // ����Ƿ��¿ո��
        if (Input.GetKeyDown(keyCode))
        {
            if (isHidden)
            {
                // ��������Ѿ������أ�����ʾ���ǲ��������ɵ�Prefab
                ShowObjects();
                DestroySpawnedObjects(); // �Ƴ����ɵ�Prefab
            }
            else
            {
                // ������嵱ǰ�ǿɼ��ģ����������ǲ���ÿ��λ�������µ�Prefab
                HideObjects();
                SpawnObjectsAtEachLocation(); // ��ÿ�����������λ������Prefab
            }

            // �л�����״̬
            isHidden = !isHidden;
        }
    }

    // ���� objectsToHide �����е���������
    void HideObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false); // ��������
            }
        }
    }

    // ��ʾ objectsToHide �����е���������
    void ShowObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(true); // ��ʾ����
            }
        }
    }

    // ��ÿ�����������λ������Prefab
    void SpawnObjectsAtEachLocation()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null && objectToSpawn != null)
            {
                // ��ÿ�����������λ�ú���ת����Prefab
                Instantiate(objectToSpawn, obj.transform.position, obj.transform.rotation);
            }
        }

       // isSpawned = true; // ����Ѿ������˶���
    }

    // �����������ɵ�Prefab
    void DestroySpawnedObjects()
    {
        // �ҵ����д��� "SpawnedObject" ��ǩ�Ķ���
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");

        foreach (GameObject spawnedObject in spawnedObjects)
        {
            if (spawnedObject != null)
            {
                Destroy(spawnedObject); // �������ɵ�Prefab
            }
        }

       // isSpawned = false; // ��������״̬
    }
}
