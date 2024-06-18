using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayRotateObject : MonoBehaviour
{
    [SerializeField] private bool AxisX = false;
    [SerializeField] private bool AxisY = false;
    [SerializeField] private bool AxisZ = false;
    [SerializeField] private float targetAngle;
    [SerializeField] private bool IsRandom = false;

    private Transform turretTransform; // Ссылка на трансформ башни танка
    public float rotationSpeed = 90f; // Скорость вращения в градусах в секунду
    public float delayBetweenRotations = 2f; // Задержка между вращениями (в секундах)

    private Quaternion originalRotation; // Исходное положение башни
    private float targetRotation = 0f; // Целевой угол вращения
    private float currentRotation = 0f; // Текущий угол вращения
    private bool isRotating = false; // Флаг, указывающий, происходит ли вращение
    private float timeSinceLastRotation = 0f; // Время, прошедшее с последнего вращения
    private bool rotateClockwise = true; // Флаг, указывающий направление вращения

    private void Start()
    {
        if (IsRandom)
        {
            targetAngle = Random.Range(-90f, 90f);
            rotationSpeed = Random.Range(10f, 50f);
            delayBetweenRotations = Random.Range(0f, 8f);
        }

        turretTransform = gameObject.transform;
        if (gameObject.transform.root.GetComponent<Destructible>() != null)
        {
            gameObject.transform.root.GetComponent<Destructible>().OnDeadEvent.AddListener(Stop);
        }
        
        // Запоминаем исходное положение башни
        originalRotation = turretTransform.localRotation;

        // Начинаем вращение сразу
        StartRotation();
    }

    private void Update()
    {
        // Если происходит вращение, продолжаем ее
        if (isRotating)
        {
            RotateTurret();
        }
        else
        {
            // Отслеживаем время, прошедшее с последнего вращения
            timeSinceLastRotation += Time.deltaTime;

            // Если прошло достаточно времени, начинаем новое вращение
            if (timeSinceLastRotation >= delayBetweenRotations)
            {
                StartRotation();
            }
        }
    }

    private void StartRotation()
    {
        isRotating = true;
        timeSinceLastRotation = 0f;

        // Устанавливаем целевой угол вращения
        targetRotation = rotateClockwise ? targetAngle : -targetAngle; // -Если `rotateClockwise` равно `true`, `targetRotation` устанавливается в 90f, что означает поворот на 90 градусов по часовой стрелке.
                                                       //-Если `rotateClockwise` равно `false`, `targetRotation` устанавливается в -90f, что означает поворот на 90 градусов против часовой стрелки.
        rotateClockwise = !rotateClockwise; // Инвертирует значение `rotateClockwise`, чтобы в следующий раз объект вращался в противоположном направлении.
    }

    private void RotateTurret()
    {
        // Вращаем башню
        currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (AxisX == true)
        {
            turretTransform.localRotation = Quaternion.Euler(currentRotation, 0f, 0f);
        }

        if (AxisY == true)
        {
            turretTransform.localRotation = Quaternion.Euler(0f, currentRotation, 0f);
        }
        if (AxisZ == true)
        {
            turretTransform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
        }

        

        // Если достигли целевого угла, заканчиваем вращение
        if (Mathf.Approximately(currentRotation, targetRotation))
        {
            isRotating = false;
        }
    }

    private void Stop()
    {
        this.enabled = false;
    }
}
