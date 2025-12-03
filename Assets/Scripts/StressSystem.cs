using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class StressSystem : MonoBehaviour
{
    [SerializeField] float stepIncreaseValue = 5f;

    [Space(20)]


    [SerializeField] GameManager gameManager;
    [SerializeField] Volume postProcessVolume;
    [Space(20)]

    [SerializeField] int corretOrders = 0;
    [SerializeField] int incorrectOrders = 0;

    [SerializeField] float stressLevel = 0f;



    private void Awake()
    {
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();

        if (!gameManager)
        {
            Debug.LogError("GameManager not found in StressSystem");
        }

        if (!postProcessVolume)
        {
            Debug.LogError("PostProcessVolume not assigned in StressSystem");
        }


    }

        void Update()
        {
            UpdateValues();
            UpdateStressLevel();
        }

        void UpdateValues()
        {
            corretOrders = gameManager.correctOrders;
            incorrectOrders = gameManager.incorrectOrders;
        }

        void UpdateStressLevel()
        {
            stressLevel = (incorrectOrders - corretOrders) * stepIncreaseValue;

            postProcessVolume.weight = Mathf.Clamp((incorrectOrders - corretOrders) * stepIncreaseValue, 0f, 1f);
        }

    
}

