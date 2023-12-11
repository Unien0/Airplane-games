using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalManager : MonoBehaviour
{
    public GameObject particlePrefab; // 粒子预制体
    public int poolSize = 30; // 对象池的大小

    private List<GameObject> particlePool;

    private void Awake()
    {
        EventCenter.AddListener<Vector2>(EventType.SpaceArtPublishParticle, PlayParticleFromPool);
    }

    void Start()
    {
        InitializePool();
        // 示例：从对象池中获取并播放粒子
        PlayParticleFromPool(Vector2.zero);
    }

    void InitializePool()
    {
        particlePool = new List<GameObject>();

        // 预先实例化一定数量的粒子对象并加入对象池
        for (int i = 0; i < poolSize; i++)
        {
            GameObject particle = Instantiate(particlePrefab, transform);
            particle.SetActive(false);
            particlePool.Add(particle);
        }
    }

    // 从对象池中获取粒子对象
    GameObject GetParticleFromPool()
    {
        foreach (GameObject particle in particlePool)
        {
            if (!particle.activeInHierarchy)
            {
                return particle;
            }
        }

        // 如果对象池中没有可用的对象，可以选择扩展池大小或实现其他处理逻辑
        return null;
    }

    // 播放粒子效果
    void PlayParticleFromPool(Vector2 position)
    {
        GameObject particle = GetParticleFromPool();

        if (particle != null)
        {
            particle.transform.position = position;
            particle.SetActive(true);

            // 在这里你可以根据需要操纵粒子的其他属性
            // 例如，使用 particle.GetComponent<ParticleSystem>().Play() 来播放粒子系统
            StartCoroutine(ReturnParticleAfterDelay(particle));
        }
    }

    // 模拟延迟后将粒子对象返回对象池
    IEnumerator ReturnParticleAfterDelay(GameObject particle)
    {
        // 假设延迟2秒后将粒子对象返回对象池
        yield return new WaitForSeconds(2f);

        // 将粒子对象返回对象池
        ReturnParticleToPool(particle);
    }

    // 将粒子对象返回对象池
    void ReturnParticleToPool(GameObject particle)
    {
        particle.SetActive(false);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<Vector2>(EventType.SpaceArtPublishParticle, PlayParticleFromPool);
    }
}
