using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class NetworkClientSamples : MonoBehaviour
{
    public WWWSamples www;
    public WebRequestSamples webRequest;
    
    void Start()
    {
        //www.Get().Forget();
        //www.Post().Forget();

        //webRequest.Get().Forget();
        //webRequest.Post().Forget();

        var httpWebRequest = new HttpWebRequestSamples();
        httpWebRequest.Get().Forget();
        //httpWebRequest.Post().Forget();
    }

}
