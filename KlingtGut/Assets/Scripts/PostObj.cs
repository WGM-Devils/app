using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class PostObj : MonoBehaviour
{



    public GameObject Posts;
    public Posts Message;
    public int Id;
    public Text userId;
    public Text Title;
    public Text description;
    public Text commentsCount;
    public Text likesCount;
    public Text viewsCount;
    public Text createdAt;
    public VideoPlayer videoPlayer;


    public void Start()
    {

    }

    private void Update()
    {
        Message = Posts.GetComponent<PostRequest>().Data.posts[Id];

        Title.text = Message.title;

        #region
       // videoPlayer.url = "https://rr2---sn-ab5sznld.googlevideo.com/videoplayback?expire=1701287608&ei=WEJnZYOaDN-4_9EP6cKG6Aw&ip=91.240.71.149&id=o-AAG8icnKqLJqq-bvtu-TgcQfuduz_2fYoAAVY4YUo4In&itag=18&source=youtube&requiressl=yes&xpc=EgVo2aDSNQ%3D%3D&pcm2=no&spc=UWF9f5VIJDUb-zbly60vlsALlSL-OIA&vprv=1&svpuc=1&mime=video%2Fmp4&gir=yes&clen=8776480&ratebypass=yes&dur=213.056&lmt=1666900498443448&fexp=24007246&c=ANDROID&txp=4530434&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cxpc%2Cpcm2%2Cspc%2Cvprv%2Csvpuc%2Cmime%2Cgir%2Cclen%2Cratebypass%2Cdur%2Clmt&sig=ANLwegAwRAIgdAEr6ExBqLGfxsajQWp2tUrryc4rS98o5rhJ7XhkSfECIB9GuiaAgzo56meuPZYFbwU0Lzju8WNUamTjyM-TYdQr&title=RickRoll%27D&redirect_counter=1&rm=sn-gjo-w43s7e&req_id=8dd41bb64f54a3ee&cms_redirect=yes&cmsv=e&ipbypass=yes&mh=ga&mm=29&mn=sn-ab5sznld&ms=rdu&mt=1701265777&mv=m&mvi=2&pl=24&lsparams=ipbypass,mh,mm,mn,ms,mv,mvi,pl&lsig=AM8Gb2swRQIhAPNOq2xyLG_cb6nvTZk3XITp84bJQqkwraSAr4SNzRduAiAdFjfZHNvpa3qm-jESuuMeS2OgGR1nynoZfeJyBvgsxw%3D%3D";
       // videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();
        #endregion
    }
}
