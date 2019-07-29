namespace WindowsFormsApp1
{
    class AppCache
    {
        public static string API { get; } = @"trnsl.1.1.20190713T135845Z.c92248bfb60a4114.7725533a9e8977a4dc19ef0b4460f7b1705fd26a";
        public static string UrlGetAvailableLanguages { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui={1}";
        public static string UrlDetectSrcLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/detect?key={0}&text={1}";
        public static string UrlTranslateLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&langs={2}";

    }   
}
