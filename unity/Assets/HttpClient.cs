using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
   private void Start()
    {
        StartCoroutine(SendRequest());
    }

    IEnumerator SendRequest()
    {
        string url = "http://localhost:3000/"; 
        using UnityWebRequest request = UnityWebRequest.Get(url);
        // 요청 전송
        yield return request.SendWebRequest();

        // 응답 처리
        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"서버 요청 실패: {request.error}");
        }
        else
        {
            Debug.Log($"서버 응답: {request.downloadHandler.text}");
        }
    }
}
