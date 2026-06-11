using UnityEngine;

public class TacticalFocus : MonoBehaviour
{
    [Header("Настройки способности")]
    public float slowMotionFactor = 0.2f; // Насколько замедляется время (0.2 = 20% скорости)
    public KeyCode abilityKey = KeyCode.LeftShift; // Кнопка активации (Левый Shift)
    
    private float defaultTimeScale = 1f;
    private float defaultFixedDeltaTime;
    private bool isFocusActive = false;

    void Start()
    {
        defaultTimeScale = Time.timeScale;
        defaultFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        // Активация способности при нажатии
        if (Input.GetKeyDown(abilityKey) && !isFocusActive)
        {
            ActivateFocus();
        }

        // Деактивация при отпускании кнопки
        if (Input.GetKeyUp(abilityKey) && isFocusActive)
        {
            DeactivateFocus();
        }
    }

    void ActivateFocus()
    {
        isFocusActive = true;
        Time.timeScale = slowMotionFactor;
        Time.fixedDeltaTime = defaultFixedDeltaTime * slowMotionFactor; // Коррекция физики
        
        // Визуальный эффект (например, изменение цвета или пост-процессинга)
        Debug.Log("Тактический фокус АКТИВИРОВАН: Время замедлено.");
    }

    void DeactivateFocus()
    {
        isFocusActive = false;
        Time.timeScale = defaultTimeScale;
        Time.fixedDeltaTime = defaultFixedDeltaTime;
        
        Debug.Log("Тактический фокус ОТКЛЮЧЕН: Нормальная скорость.");
    }
    
    // Эту функцию можно вызвать при нажатии кнопки "Взаимодействие" (например, E)
    // пока активен фокус, чтобы убедить NPC
    public void AttemptIntimidate()
    {
        if (isFocusActive)
        {
            Debug.Log("Матео использует замедленное время для пугающего диалога. Шанс успеха повышен!");
            // Здесь будет логика проверки навыка и диалоговая система
        }
    }
}