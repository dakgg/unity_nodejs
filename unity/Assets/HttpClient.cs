using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    void Start()
    {
        // 로컬호스트는 Unity Editor에서만 작동, 실제 기기에서는 서버 주소 필요
        StartCoroutine(GetHelloMessage("http://localhost:3000/"));
    }

    IEnumerator GetHelloMessage(string url)
    {
        using UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Request Error: {request.error}");
        }
        else
        {
            Debug.Log($"Server says: {request.downloadHandler.text}");
        }
    }
}
