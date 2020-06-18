using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestSamples : MonoBehaviour
{
    //WebRequestModel model;

    //void Start()
    //{
    //    model = new WebRequestModel();
    //    model.DownloadDataAsync("https://google.co.jp")
    //        .Subscribe(response =>
    //        {
    //            Debug.Log("Subscribed:" + response);
    //        })
    //        .AddTo(this);
    //}

    const string url = "https://zipcloud.ibsnet.co.jp/api/search";
    const string key = "zipcode";
    const int zipcode = 1000005;
    string query = $"?{key}={zipcode}";

    #region GET

    public async UniTaskVoid Get()
    {
        // Coroutine
        //StartCoroutine("GetRequestCoroutine");

        // Convert to Observable
        //Observable.FromCoroutine<string>(observer => GetRequestCoroutine(observer))
        //    .Subscribe(x => Debug.Log(x))
        //    .AddTo(this);

        // Async
        //var res = await GetRequestAsync();
        //Debug.Log(res);

        /* Convert to Observable
        // 呼び出しと同時に実行される(Hot)
        //GetRequestAsync().ToObservable();
        // Subscribeするまで実行されない(Cold)
        //Observable.Defer(() => GetRequestAsync().ToObservable());
        */
    }
    private IEnumerator GetRequestCoroutine()
    {
        var request = UnityWebRequest.Get(url + query);

        {
            // ヘッダを付ける場合
            //request.SetRequestHeader("foo", "hoge");
            //request.SetRequestHeader("bar", "fuga");
        }

        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("get failure.");
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("get success.");
            Debug.Log(request.downloadHandler.text);

            {
                // Json をデシリアライズする場合
                // JsonUtility : Unity純正、速いが制約が多い
                //var data = UnityEngine.JsonUtility.FromJson<ResponseData>(request.downloadHandler.text);
                // Json.NET : C#におけるメジャーどころ、遅いが汎用的で拡張性がある
                //var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseData>(request.downloadHandler.text);
                // Utf8Json : neuecc作、JsonUtilityと同じくらいの速さで汎用的
                //var data = Utf8Json.JsonSerializer.Deserialize<ResponseData>(request.downloadHandler.text);

            }
        }
    }
    private IEnumerator GetRequestCoroutine(IObserver<string> observer)
    {
        var request = UnityWebRequest.Get(url + query);
        yield return request.SendWebRequest();
        
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("get failure.");
        }
        else
        {
            Debug.Log("get success.");
            observer.OnNext(request.downloadHandler.text);
            observer.OnCompleted();
        }
    }
    public async UniTask<string> GetRequestAsync()
    {
        var request = UnityWebRequest.Get(url + query);
        await request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("get failure.");
            return null;
        }
        else
        {
            Debug.Log("get success.");
            return request.downloadHandler.text;
        }
    }

    #endregion

    #region POST

    public async UniTaskVoid Post()
    {
        // Coroutine
        //StartCoroutine("PostRequestCoroutine");

        // Convert to Observable
        //Observable.FromCoroutine<string>(observer => PostRequestCoroutine(observer))
        //    .Subscribe(x => Debug.Log(x))
        //    .AddTo(this);

        // Async
        //var res = await PostRequestAsync();
        //Debug.Log(res);
    }
    private IEnumerator PostRequestCoroutine()
    {
        var form = new WWWForm();
        form.AddField(key, zipcode);

        {
            // 画像(バイナリ)を送信する場合
            //var postData = new byte[0];
            //form.AddBinaryData("image", postData, "sample.png", "image/ping");
        }
        {
            // ヘッダを付けて、画像(バイナリ)を送信する場合
            //var request = UnityWebRequest.Post(url, form);
            //request.SetRequestHeader("foo", "hoge");
            //request.SetRequestHeader("Content-Type", "application/octet-stream");
            //var postData = new byte[0];
            //request.uploadHandler = new UploadHandlerRaw(postData);
            //request.uploadHandler.contentType = "application/octet-stream";
            //request.downloadHandler = new DownloadHandlerBuffer();
            //yield return request.SendWebRequest();
        }

        var request = UnityWebRequest.Post(url, form);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("get failure.");
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("get success.");
            Debug.Log(request.downloadHandler.text);
        }
    }
    private IEnumerator PostRequestCoroutine(IObserver<string> observer)
    {
        var form = new WWWForm();
        form.AddField(key, zipcode);

        var request = UnityWebRequest.Post(url, form);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("post failure.");
        }
        else
        {
            Debug.Log("post success.");
            observer.OnNext(request.downloadHandler.text);
            observer.OnCompleted();
        }
    }
    public async UniTask<string> PostRequestAsync()
    {
        var form = new WWWForm();
        form.AddField(key, zipcode);

        var request = UnityWebRequest.Get(url + query);
        await request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("post failure.");
            return null;
        }
        else
        {
            Debug.Log("post success.");
            return request.downloadHandler.text;
        }
    }

    #endregion
}
