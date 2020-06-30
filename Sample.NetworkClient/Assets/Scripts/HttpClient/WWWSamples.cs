using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WWWSamples : MonoBehaviour
{
    const string url = "https://zipcloud.ibsnet.co.jp/api/search";
    const string key = "zipcode";
    const int zipcode = 7830060;
    string query = $"?{key}={zipcode}";

    #region GET

    public async UniTaskVoid Get()
    {
        // Coroutine
        StartCoroutine("GetRequestCoroutine");

        // Convert to Observable
        Observable.FromCoroutine<string>(observer => GetRequestCoroutine(observer))
            .Subscribe(x => Debug.Log(x))
            .AddTo(this);

        // Observable
        GetRequestObservable();

        // Async
        await GetRequestAsync();
    }
    private IEnumerator GetRequestCoroutine()
    {
        var www = new WWW(url + query);

        {
            // ヘッダを付ける場合
            //var header = new Dictionary<string, string>() { { "foo", "hoge" } };
            //var www = new WWW(url, null, header);
        }

        yield return www;

        if (www.error != null)
        {
            Debug.Log("get failure.");
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log($"get success. {nameof(WWWSamples)}.{nameof(GetRequestCoroutine)}");
            Debug.Log(www.text);

            {
                // Json をデシリアライズする場合
                // JsonUtility : Unity純正、速いが制約が多い
                //var data = UnityEngine.JsonUtility.FromJson<ResponseData>(www.text);
                // Json.NET : C#におけるメジャーどころ、遅いが汎用的で拡張性がある
                //var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseData>(www.text);
                // Utf8Json : neuecc作、JsonUtilityと同じくらいの速さで汎用的
                //var data = Utf8Json.JsonSerializer.Deserialize<ResponseData>(www.text);

                // Fileなどのバイナリをダウンロードした場合
                //var data = www.bytes;
            }
        }
    }
    private IEnumerator GetRequestCoroutine(IObserver<string> observer)
    {
        var www = new WWW(url + query);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("get failure.");
        }
        else
        {
            Debug.Log($"get success. {nameof(WWWSamples)}.{nameof(GetRequestCoroutine)}");
            observer.OnNext(www.text);
            observer.OnCompleted();
        }
    }
    private void GetRequestObservable()
    {
        var progress = new ScheduledNotifier<float>();
        progress.Subscribe(prog => Debug.Log(prog))
            .AddTo(this);

        ObservableWWW.Get(url + query, progress: progress)
            .Subscribe(
                x => 
                {
                    Debug.Log($"get success. {nameof(WWWSamples)}.{nameof(GetRequestObservable)}");
                    Debug.Log(x);
                },
                ex => Debug.Log(ex.Message),
                () => Debug.Log("completed."))
            .AddTo(this);
    }
    private async UniTask GetRequestAsync()
    {
        var www = new WWW(url + query);
        await www;

        if (www.error != null)
        {
            Debug.Log("get failure.");
        }
        else
        {
            Debug.Log($"get success. {nameof(WWWSamples)}.{nameof(GetRequestAsync)}");
            Debug.Log(www.text);
        }
    }

    #endregion

    #region POST

    public async UniTaskVoid Post()
    {
        // Coroutine
        StartCoroutine("PostRequestCoroutine");

        // Convert to Observable
        Observable.FromCoroutine<string>(observer => PostRequestCoroutine(observer))
            .Subscribe(x => Debug.Log(x))
            .AddTo(this);

        // Observable
        PostRequestObservable();

        // Async
        await PostRequestAsync();
    }
    private IEnumerator PostRequestCoroutine()
    {
        var form = new WWWForm();
        form.AddField(key, zipcode);

        {
            // 画像(バイナリ)を送信する場合
            //var postData = new byte[] { 1, 2 };
            //form.AddBinaryData("image", postData, "sample.png", "image/png");
        }
        {
            // ヘッダを付けて、画像(バイナリ)を送信する場合
            //var header = new Dictionary<string, string>() 
            //{
            //    { "foo", "hoge" },
            //    { "Content-Type", "application/octet-stream" },
            //};
            //var postData = new byte[] { 1, 2 };
            //var www = new WWW(url, postData, header);
        }

        var www = new WWW(url, form);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("post failure.");
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log($"post success. {nameof(WWWSamples)}.{nameof(PostRequestCoroutine)}");
            Debug.Log(www.text);
        }
    }
    private IEnumerator PostRequestCoroutine(IObserver<string> observer)
    {
        var form = new WWWForm();
        form.AddField(key, zipcode);

        var www = new WWW(url, form);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("post failure.");
        }
        else
        {
            Debug.Log($"post success. {nameof(WWWSamples)}.{nameof(PostRequestCoroutine)}");
            observer.OnNext(www.text);
            observer.OnCompleted();
        }
    }
    private void PostRequestObservable()
    {
        var form = new WWWForm();
        form.AddField(key, zipcode);

        var progress = new ScheduledNotifier<float>();
        progress.Subscribe(prog => Debug.Log(prog))
            .AddTo(this);

        ObservableWWW.Post(url, form, progress)
            .Subscribe(x =>
            {
                Debug.Log($"post success. {nameof(WWWSamples)}.{nameof(PostRequestObservable)}");
                Debug.Log(x);
            })
            .AddTo(this);
    }
    private async UniTask PostRequestAsync()
    {
        var form = new WWWForm();
        form.AddField(key, zipcode);

        var www = new WWW(url, form);
        await www;

        if (www.error != null)
        {
            Debug.Log("post failure.");
        }
        else
        {
            Debug.Log($"post success. {nameof(WWWSamples)}.{nameof(PostRequestAsync)}");
            Debug.Log(www.text);
        }
    } 

    #endregion
}