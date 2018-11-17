using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;

namespace WebApplication1.Resource
{
    public static class Splitter
    {
        public static string[] stringsplitter(string text, string splitcharacter)
        {
            return text.Split(splitcharacter);
        } 
    }
}