using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTankRotate : MonoBehaviour
{
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
        turretTransform = gameObject.GetComponent<Tank>().Tower.transform;
        gameObject.GetComponent<Destructible>().OnDeadEvent.AddListener(Stop);
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
        targetRotation = rotateClockwise ? 90f : -90f;
        rotateClockwise = !rotateClockwise;
    }

    private void RotateTurret()
    {
        // Вращаем башню
        currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        turretTransform.localRotation = Quaternion.Euler(0f, currentRotation, 0f);

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
