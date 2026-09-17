using UnityEngine;
using Vuforia;

public class MorphingController : MonoBehaviour
{
    public MeshFilter[] models; // 存储五个模型的 MeshFilter
    public float transitionDuration = 2f; // 每段动画的过渡时间

    public MeshFilter currentMeshFilter; // 当前显示的 MeshFilter
    private Mesh targetMesh; // 目标模型的 Mesh
    private int currentIndex = 0; // 当前模型索引
    private float timer = 0f; // 计时器
    private bool isTracking = false; // 是否正在跟踪目标

    void Start()
    {
        // 初始化当前 MeshFilter
        //currentMeshFilter = GetComponent<MeshFilter>();
        //currentMeshFilter.mesh = models[0].sharedMesh; // 设置初始模型

        // 监听 ImageTarget 的跟踪状态
        var trackable = GetComponentInParent<DefaultObserverEventHandler>();
        if (trackable != null)
        {
            trackable.OnTargetFound.AddListener(() =>
            {
                Debug.Log("Target Found - Starting Animation");
                isTracking = true; // 开始动画
            });

            trackable.OnTargetLost.AddListener(() =>
            {
                Debug.Log("Target Lost - Stopping Animation");
                isTracking = false; // 停止动画
            });
        }
    }

    void Update()
    {
        //if (!isTracking) return; // 如果没有跟踪到目标，暂停动画

        // 动画逻辑
        timer += Time.deltaTime;
        if (timer >= transitionDuration)
        {
            // 切换到下一个模型
            currentIndex = (currentIndex + 1) % models.Length;


            targetMesh = models[currentIndex].sharedMesh;
            Debug.Log(currentIndex);
            Debug.Log(targetMesh);
            timer = 0f; // 重置计时器
        }

        MorphToTarget(currentMeshFilter.mesh, targetMesh, timer / transitionDuration);
    }

    void MorphToTarget(Mesh fromMesh, Mesh toMesh, float t)
    {
        // 确保模型的顶点数量一致
        Vector3[] fromVertices = fromMesh.vertices;
        Vector3[] toVertices = toMesh.vertices;
        
        if (fromVertices.Length != toVertices.Length)
        {
            Debug.LogError("Vertex count mismatch between models!");
            //return;
        }

        // 插值顶点
        Vector3[] morphedVertices = new Vector3[fromVertices.Length];
        for (int i = 0; i < fromVertices.Length; i++)
        {
            if (toVertices.Length < i)
                morphedVertices[i] = Vector3.Lerp(fromVertices[i], toVertices[i], t);
        }

        // 应用插值结果到当前模型
        currentMeshFilter.mesh.vertices = morphedVertices;
        currentMeshFilter.mesh.RecalculateNormals(); // 确保光照正确
    }
}
