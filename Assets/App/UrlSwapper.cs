using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class UrlSwapper : MonoBehaviour, IInputClickHandler
{
    private List<DynamicTextureDownloader> _textureDownloaders;

    private List<DynamicTextureDownloader> GetTextureDownloaders()
    {
        if (_textureDownloaders == null)
        {
            _textureDownloaders = new List<DynamicTextureDownloader>();
            foreach (Transform gameObj in transform.parent.transform)
            {
                _textureDownloaders.Add(gameObj.GetComponent<DynamicTextureDownloader>());
            }
        }
        return _textureDownloaders;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var tmpUrl = GetTextureDownloaders()[0].ImageUrl;
        GetTextureDownloaders()[0].ImageUrl = GetTextureDownloaders()[1].ImageUrl;
        GetTextureDownloaders()[1].ImageUrl = tmpUrl;
    }
}
