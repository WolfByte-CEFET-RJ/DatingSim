using UnityEngine;

public class MovimentoRocket : MonoBehaviour
{
    public float amplitude = 30f; // Amplitude m�xima do movimento (altura total)
    public float initialFrequency = 0.5f; // Frequ�ncia inicial do movimento (velocidade inicial)
    public float accelerationDuration = 60f; // Tempo para a acelera��o (em segundos)
    public float maxFrequencyMultiplier = 2f; // Multiplicador m�ximo para a frequ�ncia final
    public float tiltAngle = 5f; // �ngulo de inclina��o m�xima

    private float elapsedTime = 0f; // Tempo decorrido desde o in�cio da acelera��o
    private float frequency; // Frequ�ncia atual do movimento
    private float initialYPosition; // Posi��o inicial em Y
    private Vector3 initialRotation; // Rota��o inicial do GameObject
    private bool endOfTheGame = false;
    // Start is called before the first frame update

    void Start()
    {
        initialYPosition = transform.localPosition.y; // Salva a posi��o inicial em Y
        initialRotation = transform.localEulerAngles; // Salva a rota��o inicial do GameObject
        frequency = initialFrequency; // Define a frequ�ncia inicial
        endOfTheGame = false;
    }

    void Update()
    {
        if (endOfTheGame)
        {
            this.enabled = false;
        }

        // Atualiza o tempo decorrido
        elapsedTime += Time.deltaTime;

        // Calcula a frequ�ncia atual com base na acelera��o ao longo do tempo
        float t = Mathf.Clamp01(elapsedTime / accelerationDuration); // Normaliza o tempo de 0 a 1
        frequency = Mathf.Lerp(initialFrequency, initialFrequency * maxFrequencyMultiplier, t);

        // Calcula um deslocamento vertical aleat�rio usando uma fun��o PerlinNoise
        float randomOffset = Mathf.PerlinNoise(Time.time * frequency, 0) * amplitude * 2 - amplitude;

        // Aplica o deslocamento vertical ao GameObject
        transform.localPosition = new Vector3(transform.localPosition.x, initialYPosition + randomOffset, transform.localPosition.z);

        // Calcula a inclina��o com base na dire��o do movimento
        float tilt = Mathf.Clamp(randomOffset, -amplitude, amplitude) / amplitude * tiltAngle;

        // Ajusta a rota��o do GameObject com base no movimento
        transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y, -tilt);

        // Opcional: Para o movimento ap�s a dura��o da acelera��o
        if (elapsedTime >= accelerationDuration)
        {
            // Opcional: reseta o tempo decorrido para repetir o ciclo
            // elapsedTime = 0f;
        }
    }

    public void setEndOfTheGame()
    {
        endOfTheGame = true;
    }
}