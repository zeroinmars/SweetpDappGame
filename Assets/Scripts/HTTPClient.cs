using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
public class HTTPClient : MonoBehaviour
{
    public static HTTPClient _instance;
    public static HTTPClient instance
    {

        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                _instance = FindObjectOfType<HTTPClient>();
            }

            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GET(string url, Action<string> callback)
    {
        StartCoroutine(WaitForRequest(url, callback));
    }

    public void POST(string url, string input, Action<string> callback)
    {
        StartCoroutine(WaitForRequest(url,input, callback));
    }

    public IEnumerator WaitForRequest(string url, Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                callback(www.downloadHandler.text);
            }
        }
    }

    private IEnumerator WaitForRequest(string url, string input, Action<string> callback)
    {
        byte[] bodyRaw = Encoding.UTF8.GetBytes(input);

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                callback(www.downloadHandler.text);
            }
        }
    }
}
