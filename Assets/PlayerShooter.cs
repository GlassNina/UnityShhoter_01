using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private string _crosshair = "0";
    [SerializeField] private int _crosshairSize = 20;
    private GameObject _enemy; // Добавляем поле для ссылки на текущего врага

    void Start()
    {
        _camera = GetComponent<Camera>();
        CursorOff();
    }

    void CursorOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenCenter = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                EnemyReact enemyReact = hit.transform.GetComponent<EnemyReact>();

                if (enemyReact != null)
                {
                    enemyReact.ReactToHit();
                    _enemy = hit.transform.gameObject; // Запоминаем текущего врага
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }

        // Проверяем, не был ли объект уничтожен другими скриптами перед его уничтожением
        if (_enemy != null && Input.GetMouseButtonDown(0))
        {
            Destroy(_enemy);
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1.0f);

        // Проверяем, не был ли объект уничтожен другими скриптами перед его уничтожением
        if (sphere != null)
        {
            Destroy(sphere);
        }
    }

    void OnGUI()
    {
        float posX = _camera.pixelWidth / 2;
        float posY = _camera.pixelHeight / 2;
        GUI.Label(new Rect(posX, posY, _crosshairSize, _crosshairSize), _crosshair);
    }
}